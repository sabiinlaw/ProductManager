using System;
using System.Collections.Generic;
using System.Linq;
using ProductManagerApp.Domain.Core;
using ProductManagerApp.Domain.Interfaces;

namespace ProductManagerApp.Infrastructure.Data
{
   public class AccountRepository : IUnitOfWork<User>, IAuth
    {
        private ProductContext db;
        public AccountRepository(ProductContext context)
        {
            this.db = context;
        }
        public void Create(User item)
        {
            db.Users.Add(item);
            this.Save();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetByCredentials(string email, string password)
        {
           return db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
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

        public User GetByEmail(string email)
        {
            return db.Users.FirstOrDefault(u => u.Email == email);
        }

        public void AddNewUser(User user)
        {
            this.Create(user);
        }
    }
}
