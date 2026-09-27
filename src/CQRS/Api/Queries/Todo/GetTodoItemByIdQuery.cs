using Api.Responses.Todo;
using MediatR;

namespace Api.Queries.Todo
{
    public class GetTodoItemByIdQuery : IRequest<TodoItemDto?>
    {
        public Guid Id { get; set; }
    }
}
