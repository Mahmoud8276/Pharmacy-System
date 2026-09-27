using Mapster;
using Microsoft.Extensions.Logging;
using Pharmacy.System.Core.Dtos.ProductDtos;
using Pharmacy.System.Core.Interfaces;
using Pharmacy.System.Core.Models;
using Pharmacy.System.Services.Helpers;
using Pharmacy.System.Services.IServices;
using Pharmacy.System.Services.Responses;
using Pharmacy.System.Services.SpecificationParams;
using System;
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

        private async Task<Response> ValidateProductDto(ProductDto dto)
        {
            if (await _unitOfWork.ProductRepository.AnyAsync(x => x.Barcode == dto.Barcode))
            {
                return Response.Fail(
                    message: "Product barcode already exists!",
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

           return Response.Success(
                message: "Product deleted successfully",
                statusCode: (int)HttpStatusCode.OK);
        }

        public Task<Response> GetAllAsync(ProductSpecParams specParams)
        {
            throw new global::System.NotImplementedException();
        }

        public async Task<Response> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
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

        public Task<Response> UpdateAsync(int id, ProductDto dto)
        {
            throw new global::System.NotImplementedException();
        }
    }
}
