using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.System.Core.Dtos.ProductCategoryDtos;
using Pharmacy.System.Services.IServices;
using Pharmacy.System.Services.SpecificationParams;
using System.Threading.Tasks;

namespace Pharmacy.System.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    public class ProductCategoryController : BaseController
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProductCategoryDto dto)
        {
            var result = await _productCategoryService.CreateAsync(dto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] ProductCategorySpecParams specParams)
        {
            var result = await _productCategoryService.GetAllAsync(specParams);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _productCategoryService.GetByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ProductCategoryDto dto)
        {
            var result = await _productCategoryService.UpdateAsync(dto, id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _productCategoryService.DeleteAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
