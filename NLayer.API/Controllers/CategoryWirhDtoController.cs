using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class CategoryWirhDtoController : CustomBaseController
    {
        private readonly IServiceWithDto<Category, CategoryDto> _serviceWithDto;

        public CategoryWirhDtoController(IServiceWithDto<Category, CategoryDto> serviceWithDto)
        {
            _serviceWithDto = serviceWithDto;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CreateActionResult(await _serviceWithDto.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryDto category)
        {
            return CreateActionResult(await _serviceWithDto.AddAsync(category));
        }
    }
}
