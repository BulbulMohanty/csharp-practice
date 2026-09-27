using Api.Commands.Todo;
using Api.DB;
using MediatR;

namespace Api.CommandHandlers.Todo
{
    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public DeleteTodoItemCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteTodoItemCommand command, CancellationToken cancellationToken)
        {
            var todo = await _context.TodoItems.FindAsync([command.Id], cancellationToken);
            if (todo is null)
            {
                return false;
            }

            _context.TodoItems.Remove(todo);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
