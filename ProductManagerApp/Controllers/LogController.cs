using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;
using ProductManagerApp.Filters;
using ProductManagerApp.Services.Interfaces;

namespace ProductManagerApp.Controllers
{
    public class LogController : BaseController
    {
        ILogService _logService;//log service
        public LogController(ILogService logService)
        {
            _logService = logService;
        }
        [Authentication]
        [PMappAuthorize(Roles = "admin")]
        public ActionResult Index()
        {
            var logs = _logService.GetAll();
            logs.ForEach(l =>
            {
                StringBuilder formattedRequest = new StringBuilder();
                var serializedLogParams = l.SerializedRequest;
                Dictionary<string, string> logParamsCollection = new Dictionary<string, string>();
                logParamsCollection = JsonConvert.DeserializeObject<Dictionary<string, string>>(serializedLogParams);
                foreach (var item in logParamsCollection)
                {
                    formattedRequest.Append(item.Key + ": " + item.Value + "\n");
                }
                l.SerializedRequest = formattedRequest.ToString();
            });
            logs = logs.OrderByDescending(x => x.TimeStamp).ToList();
            return View(logs);
        }
    }
}