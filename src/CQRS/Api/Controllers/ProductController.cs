using Api.Commands.Product;
using Api.DB;
using Api.Queries.Product;
using Api.Requests.Product;
using Api.Responses.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Immutable;

namespace Api.Controllers
{
    [ApiController]
    [Route("[api/products]")]
    public class ProductController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductController(ApplicationDbContext dbContenxt, ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts(CancellationToken cancellationToken)
        {
            GetProductsQuery getProductsQuery = new();
            IEnumerable<ProductDto> products = await _sender.Send(getProductsQuery, cancellationToken);
            return Ok(products);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateProduct(CreateProductRequest createProductRequest, CancellationToken cancellationToken)
        {
            CreateProductCommand createProductCommand = new() { 
                Name = createProductRequest.Name, 
                Price = createProductRequest.Price 
            };

            var productId = await _sender.Send(createProductCommand, cancellationToken);
            return Ok(productId);
        }
    }
}
