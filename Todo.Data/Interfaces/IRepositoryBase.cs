using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Domain.Business;

namespace Todo.Data.Interfaces
{
    public interface IRepositoryBase<T> where T : Entity
    {
        Task<List<T>> Get();

        Task<T> Get(string id);

        Task<T> Create(T entity);

        Task Update(string id, T entityIn);

        Task Remove(string id);
    }
}
