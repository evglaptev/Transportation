using Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Server.Entities;

namespace Portal
{
    public class Drivers : IDrivers
    {

        IDictionary<int, Driver> driversDictionary;
        public int createPerson(Person human)
        {
            throw new NotImplementedException();
        }

        public bool delPersonById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> getAllPersons()
        {
            throw new NotImplementedException();
        }

        public int getDriverForOrderId(int key)
        {
            throw new NotImplementedException();
        }

        public Person getPersonById(int id)
        {
            throw new NotImplementedException();
        }
    }
}