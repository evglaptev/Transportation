using Portal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Entities;

namespace Portal
{
    class Drivers : IDrivers
    {

        IDictionary<int, Driver> driversDictionary;
        public Drivers(IDictionary<int, Driver> driversDictionary)
        {
            this.driversDictionary = driversDictionary;
        }

        public Person getPersonById(int id)
        {
            Driver driver;
            driversDictionary.TryGetValue(id, out driver);
            return driver;
        }

        public IEnumerable<Person> getAllPersons()
        {
            IEnumerable<Driver> dict = driversDictionary.Values.AsEnumerable();

            return dict;

        }

        public int createPerson(Person person)
        {
            if (person == null) throw new ArgumentNullException("Person param is null.");

            int key = driversDictionary.Max(p => p.Key) + 1;
            person.Id = key;
            driversDictionary.Add(key, (Driver)person);
            return key;
        }

        public bool delPersonById(int id)
        {
            bool result = driversDictionary.Remove(id);
            return result;
        }

        public int getDriverForOrderId(int key)
        {
            // It has to considered order`s parametrs (weight, size, etc.)
            Driver driver = driversDictionary.Values.Where(p => p.isFree == true).First();
            return driver.Id;

        }

    }
}