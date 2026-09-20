using Api.Responses.Product;
using MediatR;

namespace Api.Queries.Product
{
    public class GetProductsQuery: IRequest<IEnumerable<ProductDto>>
    {

    }
}
