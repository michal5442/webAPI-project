using DTOs;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebAopiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ProductDTO>> Get(int[]? categoryId, int? minPrice, int? maxPrice, int? limit, int? page)
        {
            List<ProductDTO> products = await service.GetProducts(categoryId,minPrice, maxPrice,limit,page);
            if (products == null)
            {
                return NoContent();
            }
            return Ok(products);
        }
    }
}
