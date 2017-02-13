using Portal.Entities;
using Portal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal
{
    class Managers :  IManagers
    {

        IDictionary<int, Manager> managersDictionary;

        public Managers(IDictionary<int, Manager> managersDictionary)
        {
            this.managersDictionary = managersDictionary;
        }

        /*
public Managers(IDictionary<int, Manager> managersDictionary)
{
   this.managersDictionary = managersDictionary;
}

public bool delManagerById(int managerId)
{
   return delPersonById(managerId, (IDictionary<int, Person>)managersDictionary);
}

public IEnumerable<Manager> getAllManagers()
{
   return (IEnumerable<Manager>)getAllPersons((IDictionary<int, Person>)managersDictionary);
}

public Manager getManagerById(int managerId)
{
   return (Manager)getPersonById(managerId, (IDictionary<int, Person>)managersDictionary);
}
*/

        public int getManagerForOrderId(int orderId)
        {
            int minOrderCount = managersDictionary.Values.Min(p => p.getOrdersCount());
            int managerId = managersDictionary.Values.Where(p => p.getOrdersCount() == minOrderCount).First().Id;

            //TODO Exception where min count order not found
            managersDictionary.Values.ElementAt(managerId).AddNewOrderId(orderId);
            //if (managerId == 0) throw new Exception();
            return managerId;
        }





        public Person getPersonById(int id)
        {
            Manager manager;
            managersDictionary.TryGetValue(id, out manager);
            return manager;
        }

        public IEnumerable<Person> getAllPersons()
        {
            IEnumerable<Manager> dict = managersDictionary.Values.AsEnumerable();

            return dict;

        }

        public int createPerson(Person person)
        {
            if (person == null) throw new ArgumentNullException("Person param is null.");

            int key = managersDictionary.Max(p => p.Key) + 1;
            person.Id = key;
            managersDictionary.Add(key, (Manager)person);
            return key;
        }

        public bool delPersonById(int id)
        {
            bool result = managersDictionary.Remove(id);
            return result;
        }

    





    }
}
