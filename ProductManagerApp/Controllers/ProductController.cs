using System;
using System.Web.Mvc;
using ProductManagerApp.Domain.Core;
using ProductManagerApp.Filters;
using ProductManagerApp.Services.Interfaces;

namespace ProductManagerApp.Controllers
{
    public class ProductController : BaseController
    {
        ILogService logService;
        IProductService productService;

        public ProductController(ILogService _logService, IProductService _productService)
        {
            logService = _logService;
            productService = _productService;
        }
        [Authentication]
        public ActionResult Index()
        {
            var products = productService.GetAll();
            try
            {
                var log = new Log()
                {
                    ActionDescription = "Get all products",
                    SerializedRequest = CurrentAppLogs?.Dequeue(),
                    TimeStamp = DateTime.Now,
                    UserId = 1
                };
                logService.SaveLog(log);
            }
            catch { }
            return View(products);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authentication]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Add(product);
                try
                {
                    var log = new Log()
                    {
                        ActionDescription = "Add new product",
                        SerializedRequest = CurrentAppLogs?.Dequeue(),
                        TimeStamp = DateTime.Now,
                        UserId = CurrentUser.UserId
                    };
                    logService.SaveLog(log);
                }
                catch { }
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [Authentication]
        public ActionResult Edit(int id)
        {
            Product product = productService.Get(id);
            try
            {
                var log = new Log()
                {
                    ActionDescription = "Get product to edit",
                    SerializedRequest = CurrentAppLogs?.Dequeue(),
                    TimeStamp = DateTime.Now,
                    UserId = CurrentUser.UserId
                };
                logService.SaveLog(log);
            }
            catch { }
            if (product == null)
                return HttpNotFound();
            return View(product);
        }

        [HttpPost]
        [Authentication]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.Update(product);
                try
                {
                    var log = new Log()
                    {
                        ActionDescription = "Save edited product",
                        SerializedRequest = CurrentAppLogs?.Dequeue(),
                        TimeStamp = DateTime.Now,
                        UserId = CurrentUser.UserId
                    };
                    logService.SaveLog(log);
                }
                catch { }
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [Authentication]
        [PMappAuthorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            productService.Delete(id);
            try
            {
                var log = new Log()
                {
                    ActionDescription = "Delete product",
                    SerializedRequest = CurrentAppLogs?.Dequeue(),
                    TimeStamp = DateTime.Now,
                    UserId = CurrentUser.UserId
                };
                logService.SaveLog(log);
            }
            catch { }
            return RedirectToAction("Index");
        }

    }
}