using Server.Content;
using Server.Entities;
using Server.Interfaces;
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

        IDictionary<int, Manager> context = DbContext.getDictionaryPerson();
        IDictionary<int, Order> ordersContext = DbContext.getDictionaryOrders();


        public Server()
        {
            Managers = new Managers(context);
            
        }

        public int addOrder(Order order) {
            int key = ordersContext.Keys.Count;
            int managerId = Managers.getManagerForOrderId(key);
            order.ManagerId = managerId;
            order.OrderId = key;
            ordersContext.Add(key, order);
            int driverId = Drivers.getDriverForOrderId(key);
            
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

        public Manager getManagerById(int managerId)
        {
            Manager mng = (Manager)Managers.getPersonById(managerId);
            if (mng == null) throw new NullReferenceException("Manager with id " + managerId + " not found.");
            return mng;
        }

        //ITasks Tasks { get; set; }
    }
}
