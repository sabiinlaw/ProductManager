using ProductManagerApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagerApp.Services.Interfaces
{
    public interface IAccountService
    {
        User GetUser(string email, string password);
        User GetUser(string email);
        void AddNewUser(string email, string password, int age);
    }
}
