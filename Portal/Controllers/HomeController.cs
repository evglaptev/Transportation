using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Ninject;
using Portal.Entities;
using Portal.Interfaces;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        IServer serv;
        [Inject]
       // public IAuthentication1 auth { get; set; }
        //private Client CurrentUser
        //{
            //get
            //{
                //return serv.getClientByPhone(auth.CurrentClient.Identity.Name);

            //}
        //}
        
        public HomeController()
        {
            serv = Portal.Server.getServer();

        }

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                
                return UserManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.PhoneNumber, PhoneNumber = model.PhoneNumber };
                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        //public ActionResult userLogin()
        //{
        //  return View();// CurrentUser);
        //}

        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult getInfoAboutOrder(int id)
        {
            Order order = serv.getOrderById(id);
            return View(order);
        }
        [HttpGet]
        public ActionResult createOrder()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createOrder(Order newOrder)
        {
           int orderId = serv.addOrder(newOrder);
            if (orderId >= 0)
            {

                return View("createOrderSuccess", orderId);

            }
            return View("createOrderFail");
        }

        public ActionResult managerInfo(int managerId)
        {
            Manager manager;
            manager = serv.getManagerById(managerId);
            return PartialView(manager);
        }

        public ActionResult driverInfo(int driverId)
        {
            Driver driver;
            driver = serv.getDriverById(driverId);
            return PartialView(driver);
        }
        [HttpGet]
        public ActionResult registerClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult registerClient(Client client)
        {
            if (serv.createClient(client))
            {
                return View("registerOk",client);
            }
            else
            {
                return View("registerFail");
            }

        }

    }
}