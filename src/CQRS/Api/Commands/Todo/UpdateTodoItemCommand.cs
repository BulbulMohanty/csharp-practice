using Api.Entities;
using MediatR;

namespace Api.Commands.Todo
{
    public class UpdateTodoItemCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public TodoPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
