using Api.Responses.Todo;
using MediatR;

namespace Api.Queries.Todo
{
    public class GetTodoItemsQuery : IRequest<IEnumerable<TodoItemDto>>
    {
        public bool? IsCompleted { get; set; }
    }
}
