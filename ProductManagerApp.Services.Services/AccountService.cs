using ProductManagerApp.Domain.Core;
using ProductManagerApp.Domain.Interfaces;
using ProductManagerApp.Infrastructure.Data;
using ProductManagerApp.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace ProductManagerApp.Services.Services
{
    public class AccountService : IAccountService
    {
        IAuth _authRepository;
        public AccountService()
        {
            _authRepository = new AccountRepository(new ProductContext());
        }
        public AccountService(IAuth authRepository)
        {
            _authRepository = authRepository;
        }
        public User GetUser(string email, string password)
        {
            string hash = null;
            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, password);
            }

            return hash != null ? _authRepository.GetByCredentials(email, hash) : null;
        }

        public User GetUser(string name)
        {
            return _authRepository.GetByEmail(name);
        }
        public void AddNewUser(string email, string password, int age)
        {
            string hash = null;
            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, password);
            }

            if(hash != null) _authRepository.AddNewUser(new User { Email = email, Password = hash, Age = age });
        }
        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder hash = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                hash.Append(data[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
