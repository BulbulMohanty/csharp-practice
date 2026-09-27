using MediatR;

namespace Api.Commands.Todo
{
    public class ToggleTodoItemStatusCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
