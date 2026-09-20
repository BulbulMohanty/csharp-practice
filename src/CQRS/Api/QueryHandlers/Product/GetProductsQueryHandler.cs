using Api.DB;
using Api.Queries.Product;
using Api.Responses.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.QueryHandlers.Product
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetProductsQueryHandler(ApplicationDbContext dbContenxt)
        {
            _context = dbContenxt;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ProductDto> productNames = await _context.Products.Select(product => new ProductDto {
            Name = product.Name, Price = product.Price}).ToListAsync(cancellationToken);
            return productNames;
        }
    }
}
