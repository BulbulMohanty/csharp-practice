using MediatR;

namespace Api.Commands.Product
{
    public class CreateProductCommand: IRequest<Guid>
    {
        public required string Name { get; set; }
        public string Category { get; set; }
        public decimal Price  { get; set; }
    }
}
