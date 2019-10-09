using System;

namespace ProductManagerApp.Infrastructure.Data
{
    public class UnitOfWork
    {
        private ProductContext db = new ProductContext();
        private ProductRepository productRepository;
        private ProductLogRepository logRepository;

        public ProductRepository Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }

        public ProductLogRepository Logs
        {
            get
            {
                if (logRepository == null)
                    logRepository = new ProductLogRepository(db);
                return logRepository;
            }
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
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
