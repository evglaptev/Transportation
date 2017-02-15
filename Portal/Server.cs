using Portal.Content;
using Portal.Entities;
using Portal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal
{
    public class Server:IServer
    {
        static Server serv;
        IManagers Managers { get; set; }
        IDrivers Drivers { get; set; }

        public static IServer getServer()
        {
            if (serv == null)
            {

                serv =  new Server();
            }
            return serv;
        }

        IClients Clients { get; set; }

        IDictionary<int, Manager> testManagers = DbContext.getDictionaryManagers();
        IDictionary<int, Driver> testDrivers = DbContext.getDictionaryDrivers();
        IDictionary<int, Order> ordersContext = DbContext.getDictionaryOrders();


        private Server()
        {
            Managers = new Managers(testManagers);
            Drivers = new Drivers(testDrivers);
            
        }

        public int addOrder(Order order) {
            int key = ordersContext.Keys.Count;
            int managerId = Managers.getManagerForOrderId(key);
            order.ManagerId = managerId;
            order.OrderId = key;
            ordersContext.Add(key, order);
            int driverId = Drivers.getDriverForOrderId(key);
            order.DriverId = driverId;
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
            if (mng == null)
                throw new NullReferenceException("Manager with id " + managerId + " not found.");
            return mng;
        }
        public Driver getDriverById(int driverId)
        {
            Driver drv = (Driver)Drivers.getPersonById(driverId);

            if (drv == null)
                throw new NullReferenceException("Driver with id " + driverId + " not found.");
            return drv;
        }

        public Client getClientByPhone(string name)
        {
            throw new NotImplementedException();
        }

        public Client clientLogin(string login, string password)
        {
            throw new NotImplementedException();
        }

        //ITasks Tasks { get; set; }
    }
}
