using Api.Commands.Product;
using Api.DB;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.CommandsHandler.Product
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly ApplicationDbContext _context;

        public CreateProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            Entities.Product product = new Entities.Product { Id = Guid.CreateVersion7(), Name = command.Name, Price = command.Price };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }
    }
}
