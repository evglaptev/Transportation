using Portal.Entities;
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
        public HomeController()
        {
            serv = Portal.Server.getServer();

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
    }
}