using System.Collections.Generic;
using Todo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Todo.Domain.Business.Todo>>> Get()
        {
            return await _todoService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo.Domain.Business.Todo>> Get(string id)
        {
            var todo = await _todoService.Get(id);

            if (todo == null)
            {
                return NotFound();
            }

            return todo;
        }

        [HttpPost]
        public async Task<ActionResult<Todo.Domain.Business.Todo>> Create(Todo.Domain.Business.Todo todo)
        {
            await _todoService.Create(todo);

            return CreatedAtRoute("", new { id = todo.Id.ToString() }, todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Todo.Domain.Business.Todo todoIn)
        {
            var todo = await _todoService.Get(id);

            if (todo == null)
            {
                return NotFound();
            }

            await _todoService.Update(id, todoIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var todo = await _todoService.Get(id);

            if (todo == null)
            {
                return NotFound();
            }

            await _todoService.Remove(todo.Id);

            return NoContent();
        }
    }
}
