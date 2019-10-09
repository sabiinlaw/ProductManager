using System.Collections.Generic;

namespace ProductManagerApp.Domain.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        List<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
