using Ninject.Modules;
using ProductManagerApp.Domain.Core;
using ProductManagerApp.Domain.Interfaces;
using ProductManagerApp.Infrastructure.Data;
using ProductManagerApp.Services.Interfaces;
using ProductManagerApp.Services.Services;

namespace ProductManagerApp.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork<Product>>().To<ProductRepository>();
            Bind<IUnitOfWork<Log>>().To<ProductLogRepository>();
            Bind<IUnitOfWork<User>>().To<AccountRepository>();
            Bind<IAuth>().To<AccountRepository>();
            Bind<ILogService>().To<LogService>();
            Bind<IProductService>().To<ProductService>();
            Bind<IAccountService>().To<AccountService>();
        }
    }
}