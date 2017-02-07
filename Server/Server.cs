using Server.Content;
using Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        IManagers Managers { get; set; }
        IDrivers Drivers { get; set; }
        IClients Clients { get; set; }

        IDictionary<int, Person> context = DbContext.getDictionaryPerson();
        IDictionary<int, Order> ordersContext = DbContext.getDictionaryOrders();


        public Server()
        {
            Managers = new Managers(context);
            
        }

        public int addOrder(Order order) {
            int key = ordersContext.Keys.Count;
            ordersContext.Add(key, order);
            return key;
        }

        public IEnumerable<Order> getOrdersFrom(int minOrderId)
        {
            var query = ordersContext.Values.Where(p => p.OrderId > minOrderId);


            return query;
            //ordersContext.Values.Where(p => p.OrderId > minOrderId).AsEnumerable<Order>();
        }

        public Order getOrderById(int id)
        {
            Order order;
            ordersContext.TryGetValue(id, out order);
            return order;
        }

        


        IEnumerable<Manager> getAllManagers()
        {
            return (IEnumerable<Manager>)Managers.getAllPersons();
        }

        //ITasks Tasks { get; set; }
    }
}
