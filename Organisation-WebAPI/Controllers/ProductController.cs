using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organisation_WebAPI.Dtos.ProductDto;
using Organisation_WebAPI.Services.Products;

namespace Organisation_WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> GetProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }

        
        [HttpGet("GetProductById")]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> GetProduct(int id)
        {
            return Ok(await _productService.GetProductById(id));
        }

       [HttpGet("GetProductCount")]
        public async Task<ActionResult<ServiceResponse<int>>> GetProductCount()
        {
            var serviceResponse = await _productService.GetProductCount();
            return Ok(serviceResponse);
        }

        [HttpGet("GetProductRevenue")]
        public async Task<ActionResult<ServiceResponse<int>>> GetProductRevenue()
        {
            var serviceResponse = await _productService.GetRevenue();
            return Ok(serviceResponse);
        }


        [HttpPost("CreateProduct")]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> AddProduct(AddProductDto newProduct)
        {
            return Ok(await _productService.AddProduct(newProduct));
        }

        [HttpPut("UpdateProduct")]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> UpdateProduct(UpdateProductDto updatedProduct,int id){
            return Ok(await _productService.UpdateProduct(updatedProduct,id));
        }
        
        [HttpDelete("DeleteProduct")]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> DeleteProduct(int id){
            return Ok(await _productService.DeleteProduct(id));
        }
    }
}