using ProductManagerApp.Util;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace ProductManagerApp.Filters
{
    public class AuthenticationAttribute : FilterAttribute, IAuthenticationFilter
    {
        private PrincipalUser currentUser => ApContext.Initialize().CurrentUser();
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (currentUser == null || !currentUser.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (currentUser == null || !currentUser.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary {
                    { "controller", "Account" }, { "action", "Login" }
                   });
            }
        }
    }
}