using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProductManagerApp.Domain.Core;
using ProductManagerApp.Domain.Interfaces;

namespace ProductManagerApp.Infrastructure.Data
{
    public class ProductRepository :IUnitOfWork<Product>
    {
        private ProductContext db;

        public ProductRepository(ProductContext context)
        {
            this.db = context;
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public void Create(Product product)
        {
            db.Products.Add(product);
            this.Save();
        }

        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            this.Save();
        }

        public void Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
                db.Products.Remove(product);
            this.Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
