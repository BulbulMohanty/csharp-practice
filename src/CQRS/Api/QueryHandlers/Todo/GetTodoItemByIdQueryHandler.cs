using Api.DB;
using Api.Queries.Todo;
using Api.Responses.Todo;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.QueryHandlers.Todo
{
    public class GetTodoItemByIdQueryHandler : IRequestHandler<GetTodoItemByIdQuery, TodoItemDto?>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTodoItemByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TodoItemDto?> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
        {
            var todoEntity = await _context.TodoItems
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            return todoEntity is null ? null : _mapper.Map<TodoItemDto>(todoEntity);
        }
    }
}
