using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todo.Services.Interfaces
{
    public interface ITodoService
    {
        Task<List<Todo.Domain.Business.Todo>> Get();

        Task<Todo.Domain.Business.Todo> Get(string id);

        Task<Todo.Domain.Business.Todo> Create(Todo.Domain.Business.Todo todo);

        Task Update(string id, Todo.Domain.Business.Todo todoIn);

        Task Remove(string id);
    }
}
