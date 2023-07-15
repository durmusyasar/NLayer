using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filter;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;
using System.Net;

namespace NLayer.API.Controllers
{
    public class ProductsController : CutomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductWithCategory()
        {
            return CreateActionResult(await _productService.GetProductsWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _productService.GetAllAsync();
            var productsDtos = _mapper.Map<List<Product>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDTO>>.Success((int)HttpStatusCode.OK));
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDTO>(product);
            return CreateActionResult(CustomResponseDto<ProductDTO>.Success((int)HttpStatusCode.OK, productsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO productDto)
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDTO>(product);
            return CreateActionResult(CustomResponseDto<ProductDTO>.Success((int)HttpStatusCode.Created, productsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductDTO productDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success((int)HttpStatusCode.NoContent));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success((int)HttpStatusCode.NoContent));
        }
    }
}
