using Ninject;
using Portal.Entities;
using Portal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        IServer serv;
        [Inject]
        public IAuthentication auth { get; set; }
        private Client CurrentUser
        {
            get
            {
                return serv.getClientByPhone(auth.CurrentClient.Identity.Name);

            }
        }
        public HomeController()
        {
            serv = Portal.Server.getServer();

        }

       public ActionResult userLogin()
        {
            return View(CurrentUser);
        }

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