using Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal.Controllers
{
    public class DefaultController : Controller
    {
        static Server.Server serv;
        public DefaultController()
        {
            if (serv == null)
            {
                serv = new Server.Server();
            }
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
            return View();
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
            if (orderId>=0)
            return View("createOrderSuccess", orderId);
            return View("createOrderFail");
        }
    }
}