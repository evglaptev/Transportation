using Server;
using Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiService.Controllers
{

    public class DefaultController : ApiController
    {
        Server.Server srv;
        
        public DefaultController()
        {
            srv = new Server.Server();

        }
        public int addOrder(Order order)
        {
            return srv.addOrder(order);
        }

        public IList<Order> getNewOrders(int lastOrderId) {

            if (lastOrderId < 0)
            {
                throw new IndexOutOfRangeException("lastOrderId < 0");
            }
            return new List<Order>(srv.getOrdersFrom(lastOrderId));
        }

    }
}
