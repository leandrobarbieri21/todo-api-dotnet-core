using Todo.Data.Common;
using Todo.Data.Interfaces;

namespace Todo.Data.Repositories
{
    public class TodoRepository : RepositoryBase<Todo.Domain.Business.Todo>, ITodoRepository
    {
        public TodoRepository(IMongoDatabaseSettings settings):base(settings) { }
    }
}
