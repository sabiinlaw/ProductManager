using ProductManagerApp.Domain.Core;
using ProductManagerApp.Domain.Interfaces;
using ProductManagerApp.Services.Interfaces;
using System.Collections.Generic;

namespace ProductManagerApp.Services.Services
{
    public class ProductService : IProductService
    {
        IUnitOfWork<Product> _unitOfWork;
        public ProductService(IUnitOfWork<Product> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Product product)
        {
            _unitOfWork.Create(product);
        }

        public void Delete(int id)
        {
            _unitOfWork.Delete(id);
        }

        public Product Edit(int id)
        {
           return _unitOfWork.Get(id);
        }

        public Product Get(int id)
        {
            return _unitOfWork.Get(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _unitOfWork.GetAll();
        }

        public void Update(Product product)
        {
            _unitOfWork.Update(product);
        }
    }
}
