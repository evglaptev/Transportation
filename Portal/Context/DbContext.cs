using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.Entities;

namespace Portal.Content
{
    public class DbContext
    {
        static GeneratorUserInfo.Generator gen;
        static IDictionary<int, Driver> drivers;
        static IDictionary<int, Manager> managers;
        static DbContext()
        {
            drivers = new Dictionary<int, Driver>();
            managers = new Dictionary<int, Manager>();
            gen = new GeneratorUserInfo.Generator();

            for (int i = 0; i < 10; i++)
            {
                //Person client = new Client() { Id = i, FirstName = gen.getFirstName(), LastName = gen.getLastName(), SecondName = gen.getSecondName(), TelNumber = gen.getPhoneNumber() };
                Manager manager = new Manager() { Id = i, FirstName = gen.getFirstName(), LastName = gen.getLastName(), SecondName = gen.getSecondName(), phoneNumber = gen.getPhoneNumber() };
                Driver driver = new Driver() { Id = i, FirstName = gen.getFirstName(), LastName = gen.getLastName(), SecondName = gen.getSecondName(), phoneNumber = gen.getPhoneNumber() };

                //dict.Add(new KeyValuePair<int, Person>(client.Id, client));
                managers.Add(i, manager);

                drivers.Add(i, driver);

            }

        }


        internal static IDictionary<int, Manager> getDictionaryManagers()
        {
            return managers;
        }

        internal static IDictionary<int, Driver> getDictionaryDrivers()
        {
            return drivers;
        }

        internal static IDictionary<int, Order> getDictionaryOrders()
        {
            Dictionary < int, Order > dict = new Dictionary<int, Order>();

            return dict;
        }
    }
}
