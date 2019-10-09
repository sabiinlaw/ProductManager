using ProductManagerApp.Domain.Core;
using System.Collections.Generic;

namespace ProductManagerApp.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        void Add(Product product);
        Product Edit(int id);
        void Update(Product p);
        void Delete(int id);
    }
}
