using Server.Entities;
using Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Managers :  IManagers
    {
        //  public Managers(IDictionary<int, Person> dict) : base(dict) { }
        public Managers(IDictionary<int, Manager> managersDictionary)
        {
            this.managersDictionary = managersDictionary;
        }
            

        IDictionary<int, Manager> managersDictionary;

        public int getManagerForOrderId(int orderId)
        {
            int minOrderCount = managersDictionary.Values.Min(p => p.getOrdersCount());
            int managerId = managersDictionary.Values.Where(p => p.getOrdersCount() == minOrderCount).First().Id;

            //TODO Exception where min count order not found
            managersDictionary.Values.ElementAt(managerId).AddNewOrderId(orderId);
            //if (managerId == 0) throw new Exception();
            return managerId;
        }
        /*
        IDictionary<int, Manager> getAllManagers()
        {
            IDictionary<int,Manager> dict = (IDictionary<int, Manager>)managersDictionary.Where(p => p.Value.Type == "Manager");
            
            return dict;
        }
        */

        public Person getPersonById(int id)
        {
            Manager manager;
            managersDictionary.TryGetValue(id, out manager);
            return manager;
        }

        public IEnumerable<Person> getAllPersons()
        {
            IEnumerable<Person> dict = managersDictionary.Values.AsEnumerable();

            return dict;

            throw new NotImplementedException();
        }

        public int createPerson(Person human)
        {
            throw new NotImplementedException();
        }

        public bool delPersonById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
