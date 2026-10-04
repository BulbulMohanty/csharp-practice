using Api.Commands.Todo;
using Api.Queries.Todo;
using Api.Requests.Todo;
using Api.Responses.Todo;
using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/todos")]
    public class TodoController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public TodoController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetAll([FromQuery] bool? isCompleted, CancellationToken cancellationToken)
        {
            var query = new GetTodoItemsQuery { IsCompleted = isCompleted };
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TodoItemDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetTodoItemByIdQuery { Id = id }, cancellationToken);
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTodoItemRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateTodoItemCommand>(request);
            var id = await _sender.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id, version = "1.0" }, id);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTodoItemRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateTodoItemCommand>(request);
            command.Id = id;

            var success = await _sender.Send(command, cancellationToken);
            return success ? NoContent() : NotFound();
        }

        [HttpPatch("{id:guid}/toggle")]
        public async Task<IActionResult> ToggleStatus(Guid id, CancellationToken cancellationToken)
        {
            var success = await _sender.Send(new ToggleTodoItemStatusCommand { Id = id }, cancellationToken);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await _sender.Send(new DeleteTodoItemCommand { Id = id }, cancellationToken);
            return success ? NoContent() : NotFound();
        }
    }
}
