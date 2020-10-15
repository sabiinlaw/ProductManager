using ProductManagerApp.Util;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject.Modules;
using Ninject;
using Ninject.Web.Mvc;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;

namespace ProductManagerApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {
            BeginRequest += (src, args) => ProcessLog();
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);

            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        private void ProcessLog()
        {
            Dictionary<string, string> requestLogParams = null;
            if (!(Application["logs"] is Queue<string> logList))
            {
                Application["logs"] = logList = new Queue<string>();
            }
            try
            {
                var currentRequestParams = HttpContext.Current.Request.Params;
                requestLogParams = new Dictionary<string, string>();

                for (int idx = 0; idx < currentRequestParams.Count; idx++)
                {
                    requestLogParams.Add(currentRequestParams.Keys[idx], currentRequestParams[idx]);
                }
            }
            catch
            {
                requestLogParams.Add("Process Log Error", "Can't parse [Request].[Params] NameValueCollection");
            }
            logList.Enqueue(JsonConvert.SerializeObject(requestLogParams));
        }
              
    }
}
