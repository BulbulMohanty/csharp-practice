using Api.Commands.Todo;
using Api.DB;
using MediatR;

namespace Api.CommandHandlers.Todo
{
    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public UpdateTodoItemCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateTodoItemCommand command, CancellationToken cancellationToken)
        {
            var todo = await _context.TodoItems.FindAsync([command.Id], cancellationToken);
            if (todo is null)
            {
                return false;
            }

            todo.Title = command.Title;
            todo.Description = command.Description;
            todo.Priority = command.Priority;
            todo.DueDate = command.DueDate;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
