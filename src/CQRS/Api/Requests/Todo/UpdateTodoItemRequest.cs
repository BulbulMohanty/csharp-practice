using Api.Entities;

namespace Api.Requests.Todo
{
    public class UpdateTodoItemRequest
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public TodoPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
