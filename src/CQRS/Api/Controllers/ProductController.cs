using Api.Commands.Product;
using Api.Queries.Product;
using Api.Requests.Product;
using Api.Responses.Product;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/products")]
    public class ProductController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts(CancellationToken cancellationToken)
        {
            GetProductsQuery getProductsQuery = new();
            IEnumerable<ProductDto> products = await _sender.Send(getProductsQuery, cancellationToken);
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProduct(CreateProductRequest createProductRequest, CancellationToken cancellationToken)
        {
            CreateProductCommand createProductCommand = new()
            {
                Name = createProductRequest.Name,
                Price = createProductRequest.Price
            };

            var productId = await _sender.Send(createProductCommand, cancellationToken);
            return Ok(productId);
        }
    }
}
