using Api.DB;
using Api.Queries.Todo;
using Api.Responses.Todo;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.QueryHandlers.Todo
{
    public class GetTodoItemsQueryHandler : IRequestHandler<GetTodoItemsQuery, IEnumerable<TodoItemDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTodoItemsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TodoItemDto>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.TodoItems.AsNoTracking();

            if (request.IsCompleted.HasValue)
            {
                query = query.Where(t => t.IsCompleted == request.IsCompleted.Value);
            }

            var todoEntities = await query.OrderByDescending(t => t.CreatedAt).ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<TodoItemDto>>(todoEntities);
        }
    }
}
