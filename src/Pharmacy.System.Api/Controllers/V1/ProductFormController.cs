using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.System.Core.Dtos.ProductFormDtos;
using Pharmacy.System.Services.IServices;
using Pharmacy.System.Services.SpecificationParams;
using System.Threading.Tasks;

namespace Pharmacy.System.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    public class ProductFormController : BaseController
    {
        private readonly IProductFormService _productFormService;
        public ProductFormController(IProductFormService productFormService)
        {
            _productFormService = productFormService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProductFormDto dto)
        {
            var response = await _productFormService.CreateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] ProductFormSpecParams specParams)
        {
            var response = await _productFormService.GetAllAsync(specParams);
            return StatusCode(response.StatusCode, response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _productFormService.GetByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ProductFormDto dto)
        {
            var response = await _productFormService.UpdateAsync(dto, id);
            return StatusCode(response.StatusCode, response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _productFormService.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
