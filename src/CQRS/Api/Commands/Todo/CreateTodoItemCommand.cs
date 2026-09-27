using Api.Entities;
using MediatR;

namespace Api.Commands.Todo
{
    public class CreateTodoItemCommand : IRequest<Guid>
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public TodoPriority Priority { get; set; } = TodoPriority.Medium;
        public DateTime? DueDate { get; set; }
    }
}
