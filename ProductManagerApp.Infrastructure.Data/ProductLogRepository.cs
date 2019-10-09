using System;
using System.Collections.Generic;
using System.Linq;
using ProductManagerApp.Domain.Core;
using ProductManagerApp.Domain.Interfaces;

namespace ProductManagerApp.Infrastructure.Data
{
    public class ProductLogRepository : IUnitOfWork<Log>
    {
        private ProductContext db;
        public ProductLogRepository(ProductContext context)
        {
            this.db = context;
        }
        public void Create(Log log)
        {
            db.Logs.Add(log);
            this.Save();
        }       

        private void Save()
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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Log> GetAll()
        {
            return db.Logs.ToList();
        }

        public Log Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Log item)
        {
            throw new NotImplementedException();
        }
    }
}
