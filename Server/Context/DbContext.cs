using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Entities;

namespace Server.Content
{
    public class DbContext
    {
        internal static IDictionary<int, Manager> getDictionaryPerson()
        {
            IDictionary<int, Manager> managers = new Dictionary<int, Manager>();
            GeneratorUserInfo.Generator gen = new GeneratorUserInfo.Generator();
            for (int i = 0; i < 3; i++) {
                Person client = new Client() { Id = i, FirstName = gen.getFirstName(), LastName = gen.getLastName(), SecondName = gen.getSecondName(), TelNumber = gen.getPhoneNumber() };
                Person driver = new Driver() { Id = i + 1, FirstName = gen.getFirstName(), LastName = gen.getLastName(), SecondName = gen.getSecondName(), TelNumber = gen.getPhoneNumber() };
                Person manager = new Manager() { Id = i, FirstName = gen.getFirstName(), LastName = gen.getLastName(), SecondName = gen.getSecondName(), TelNumber = gen.getPhoneNumber() };

                //dict.Add(new KeyValuePair<int, Person>(client.Id, client));
                //dict.Add(new KeyValuePair<int, Person>(driver.Id, driver));
                managers.Add(new KeyValuePair<int, Manager>(manager.Id, (Manager)manager));

            }
            return managers;
        }

        internal static IDictionary<int, Order> getDictionaryOrders()
        {
            Dictionary < int, Order > dict = new Dictionary<int, Order>();

            return dict;
        }
    }
}
