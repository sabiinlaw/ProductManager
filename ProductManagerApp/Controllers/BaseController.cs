using ProductManagerApp.Filters;
using ProductManagerApp.Util;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProductManagerApp.Controllers
{
    public class BaseController : Controller
    {
        protected virtual PrincipalUser CurrentUser => ApContext.Initialize().CurrentUser();
        protected virtual Queue<string> CurrentAppLogs => HttpContext?.Application["logs"] as Queue<string>;
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = RedirectToAction("Login", "Account");
        }
    }
}