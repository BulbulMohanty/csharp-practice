using Api.DB;
using Api.Queries.Product;
using Api.Responses.Product;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.QueryHandlers.Product
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(ApplicationDbContext dbContenxt, IMapper mapper)
        {
            _context = dbContenxt;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            List<Entities.Product> productEntities = await _context.Products.ToListAsync(cancellationToken);
            IEnumerable<ProductDto> productDtos = _mapper.Map<IEnumerable<ProductDto>>(productEntities);
            return productDtos;
        }
    }
}
