using Api.Commands.Todo;
using Api.DB;
using MediatR;

namespace Api.CommandHandlers.Todo
{
    public class ToggleTodoItemStatusCommandHandler : IRequestHandler<ToggleTodoItemStatusCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public ToggleTodoItemStatusCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(ToggleTodoItemStatusCommand command, CancellationToken cancellationToken)
        {
            var todo = await _context.TodoItems.FindAsync([command.Id], cancellationToken);
            if (todo is null)
            {
                return false;
            }

            todo.IsCompleted = !todo.IsCompleted;
            todo.CompletedAt = todo.IsCompleted ? DateTime.UtcNow : null;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
