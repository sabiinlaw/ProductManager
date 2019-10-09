using ProductManagerApp.Domain.Core;
using ProductManagerApp.Models;
using ProductManagerApp.Services.Interfaces;
using System.Web.Mvc;
using System.Web.Security;

namespace ProductManagerApp.Controllers
{
    public class AccountController : BaseController
    {
        IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                user = _accountService.GetUser(model.Name, model.Password);                
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "There is no user with entered password");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                user = _accountService.GetUser(model.Name);
                if (user == null)
                {
                    _accountService.AddNewUser(model.Name, model.Password, model.Age);
                    user = _accountService.GetUser(model.Name, model.Password);
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Product");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User is already exists");
                }
            }

            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Product");
        }
    }
}