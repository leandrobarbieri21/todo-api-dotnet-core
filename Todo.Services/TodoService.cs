using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Data.Interfaces;
using Todo.Services.Interfaces;

namespace Todo.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<List<Todo.Domain.Business.Todo>> Get()
        {
            return await _todoRepository.Get();
        }

        public async Task<Todo.Domain.Business.Todo> Get(string id)
        {
            return await _todoRepository.Get(id);
        }

        public async Task<Todo.Domain.Business.Todo> Create(Todo.Domain.Business.Todo todo)
        {
            return await _todoRepository.Create(todo);
        }

        public async Task Update(string id, Todo.Domain.Business.Todo todoIn)
        {
            await _todoRepository.Update(id, todoIn);
        }

        public async Task Remove(string id)
        {
            await _todoRepository.Remove(id);
        }
    }
}
