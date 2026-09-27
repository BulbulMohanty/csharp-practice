using Api.Commands.Todo;
using Api.DB;
using Api.Entities;
using MediatR;

namespace Api.CommandHandlers.Todo
{
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, Guid>
    {
        private readonly ApplicationDbContext _context;

        public CreateTodoItemCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateTodoItemCommand command, CancellationToken cancellationToken)
        {
            var todo = new TodoItem
            {
                Id = Guid.CreateVersion7(),
                Title = command.Title,
                Description = command.Description,
                Priority = command.Priority,
                DueDate = command.DueDate,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow
            };

            await _context.TodoItems.AddAsync(todo, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return todo.Id;
        }
    }
}
