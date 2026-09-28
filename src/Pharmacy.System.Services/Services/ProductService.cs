using Mapster;
using Microsoft.Extensions.Logging;
using Pharmacy.System.Core.Dtos;
using Pharmacy.System.Core.Dtos.ProductDtos;
using Pharmacy.System.Core.Interfaces;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Services.Helpers;
using Pharmacy.System.Services.IServices;
using Pharmacy.System.Services.Responses;
using Pharmacy.System.Services.SpecificationParams;
using Pharmacy.System.Services.Specifications;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Pharmacy.System.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductService> _logger;

        public ProductService(
            IUnitOfWork unitofWork,
            ILogger<ProductService> logger)
        {
            _unitOfWork = unitofWork;
            _logger = logger;
        }

        private async Task<Response> ValidateProductDto(ProductDto dto, int? excludeProductId = null)
        {
            if (await _unitOfWork.ProductRepository.AnyAsync(x =>
                    x.Barcode == dto.Barcode && (excludeProductId == null || x.Id != excludeProductId)))
            {
                return Response.Fail
                    (message: "Product barcode already exists!",
                    statusCode: (int)HttpStatusCode.Conflict);
            }

            if (dto.ManufacturerId != null)
            {
                if (!await _unitOfWork.ManufacturerRepository.AnyAsync(x => x.Id == dto.ManufacturerId))
                {
                    return Response.Fail(
                        message: "Manufacturer not found!",
                        statusCode: (int)HttpStatusCode.NotFound);
                }
            }

            if (!await _unitOfWork.ProductCategoryRepository.AnyAsync(x => x.Id == dto.CategoryId))
            {
                return Response.Fail(
                    message: "Product category not found!",
                    statusCode: (int)HttpStatusCode.NotFound);
            }

            if (!await _unitOfWork.ProductFormRepository.AnyAsync(x => x.Id == dto.ProductFormId))
            {
                return Response.Fail(
                    message: "Product form not found!",
                    statusCode: (int)HttpStatusCode.NotFound);
            }

            return Response.Success();
        }
        private async Task TryDeleteImageAsync(string imageName)
        {
            try
            {
                await FileHelper.DeleteFileAsync(imageName, "ProductImages");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete image {ImageName}", imageName);
            }
        }


        public async Task<Response> CreateAsync(ProductDto dto)
        {
            var validationResult = await ValidateProductDto(dto);
            if(validationResult.IsSuccess == false)
            {
                return validationResult;
            }

            var product = dto.Adapt<Product>();

            if(dto.Image != null)
            {
                var imageName = await FileHelper.UploadFileAsync(dto.Image, "ProductImages");
                product.Image = imageName;
            }

            try
            {
                await _unitOfWork.ProductRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception)
            {
                try
                {
                    if(!string.IsNullOrEmpty(product.Image))
                    {
                        await FileHelper.DeleteFileAsync(product.Image, "ProductImages");
                    }
                }
                catch (Exception cleanupEx)
                {
                    _logger.LogError(cleanupEx, "Failed to clean up orphaned image {ImageName} after a failed product creation", product.Image);
                }

                throw;
            }

                return Response.Success(
                data: product.Adapt<ProductDetailsDto>(),
                message: "Product created successfully",
                statusCode: (int)HttpStatusCode.Created);
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if(product == null)
            {
                return Response.Fail(
                    message: "Product not found!",
                    statusCode: (int)HttpStatusCode.NotFound);
            }

            _unitOfWork.ProductRepository.Delete(product);
            await _unitOfWork.CompleteAsync();

            if (product.Image != null)
            {
                try
                {
                    await FileHelper.DeleteFileAsync(product.Image, "ProductImages");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to delete image {ImageName} for product {ProductId}", product.Image, product.Id);
                }
            }

            return Response.Success(
            message: "Product deleted successfully",
            statusCode: (int)HttpStatusCode.OK);
        }

        public async Task<Response> GetAllAsync(ProductSpecParams specParams)
        {
            var countSpec = new ProductSpecification(specParams, true);
            var count = await _unitOfWork.ProductRepository.GetCountWithSpecAsync(countSpec);

            var spec = new ProductSpecification(specParams);
            var data = await _unitOfWork.ProductRepository.GetAllWithSpecAsync(spec);

            var pagination = new Pagination(
                specParams.PageIndex,
                specParams.PageSize, 
                count,
                data.Adapt<List<ProductDetailsDto>>());

            return Response.Success(
                data: pagination,
                message: "Products retrieved successfully");
        }

        public async Task<Response> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetWithSpecAsync(new ProductSpecification(id));
            if (product == null)
            {
                return Response.Fail(
                    message: "Product not found!",
                    statusCode: (int)HttpStatusCode.NotFound);
            }

            return Response.Success(
                data: product.Adapt<ProductDetailsDto>(),
                message: "Product retrieved successfully",
                statusCode: (int)HttpStatusCode.OK);
        }

        public async Task<Response> UpdateAsync(int id, ProductDto dto)
        {
            var product = await _unitOfWork.ProductRepository.GetWithSpecAsync(new ProductSpecification(id));
            if (product == null)
                return Response.Fail(message: "Product not found!", statusCode: (int)HttpStatusCode.NotFound);

            var validationResult = await ValidateProductDto(dto, excludeProductId: id);
            if (!validationResult.IsSuccess)
                return validationResult;

            var oldImage = product.Image;
            string? newImage = null;

            dto.Adapt(product);

            if (dto.Image != null)
            {
                newImage = await FileHelper.UploadFileAsync(dto.Image, "ProductImages");
                product.Image = newImage;
            }

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception)
            {
                if (newImage != null)
                    await TryDeleteImageAsync(newImage); 
                throw;
            }

            if (newImage != null && !string.IsNullOrEmpty(oldImage))
                await TryDeleteImageAsync(oldImage);       

            return Response.Success(
                data: product.Adapt<ProductDetailsDto>(),
                message: "Product updated successfully",
                statusCode: (int)HttpStatusCode.OK);
        }
    }
}
