using Portal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Entities
{
    public class Manager : Person
    {
        public override string Type
        {
            get
            {
                Type type = typeof(Manager);
                return "Manager";
            }
        }
        
        IList<int> clientsId { get; set; }
        IList<int> driversId { get; set; }
        IList<int> ordersId { get; set; }

        public Manager()
        {
            driversId = new List<int>();
            clientsId = new List<int>();
            ordersId = new List<int>();
        }
        public void AddNewOrderId(int ordId)
        {
            ordersId.Add(ordId);
        }

        public int getOrdersCount()
        {
            return ordersId.Count;
        }


    }
}
