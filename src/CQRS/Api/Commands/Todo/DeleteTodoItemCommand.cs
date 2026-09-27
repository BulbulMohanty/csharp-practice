using MediatR;

namespace Api.Commands.Todo
{
    public class DeleteTodoItemCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
