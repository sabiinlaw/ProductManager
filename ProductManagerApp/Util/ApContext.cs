using Ninject;
using ProductManagerApp.Filters;
using ProductManagerApp.Services.Interfaces;
using ProductManagerApp.Services.Services;
using System.Web;

namespace ProductManagerApp.Util
{
    public sealed class ApContext
    {
        private static readonly object Sync = new object();
        readonly static IKernel kernel = new StandardKernel();
        private readonly IAccountService _accountService = kernel.Get<AccountService>();
        private ApContext()

        {
            HttpContext.Current.Items.Add("ApContext", this);
        }

        public static ApContext Initialize(bool createIfNotExist = true)
        {
            lock (Sync)
            {
                if (HttpContext.Current?.Items.Contains("ApContext") == true)
                    return HttpContext.Current.Items["ApContext"] as ApContext;

                return createIfNotExist ? new ApContext() : null;
            }
        }

        static ApContext()
        {

        }

        public PrincipalUser CurrentUser()
        {
            PrincipalUser principalUser = null;

            if (HttpContext.Current?.Items.Contains("PMappCurrentUser") == true)
                return HttpContext.Current.Items["PMappCurrentUser"] as PrincipalUser;

            var user = _accountService.GetUser(HttpContext.Current.User.Identity.Name);
            if (user != null)
            {
                principalUser = new PrincipalUser()
                {
                    Role = user.Role,
                    UserId = user.Id,
                    UserName = user.Email,
                    Identity = HttpContext.Current.User.Identity
                };
                HttpContext.Current.Items.Add("PMappCurrentUser", principalUser);
            }
            return principalUser;
        }
    }
}