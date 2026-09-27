using Api.Entities;

namespace Api.Requests.Todo
{
    public class CreateTodoItemRequest
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public TodoPriority Priority { get; set; } = TodoPriority.Medium;
        public DateTime? DueDate { get; set; }
    }
}
