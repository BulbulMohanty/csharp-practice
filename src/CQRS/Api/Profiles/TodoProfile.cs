using Api.Commands.Todo;
using Api.Entities;
using Api.Requests.Todo;
using Api.Responses.Todo;
using AutoMapper;

namespace Api.Profiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<CreateTodoItemRequest, CreateTodoItemCommand>();
            CreateMap<UpdateTodoItemRequest, UpdateTodoItemCommand>();
            CreateMap<TodoItem, TodoItemDto>();
        }
    }
}
