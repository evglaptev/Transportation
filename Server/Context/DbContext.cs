using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Content
{
    public class DbContext
    {
        public static IDictionary<int, Person> getDictionaryPerson()
        {
            IDictionary<int, Person> dict = new Dictionary<int, Person>();
            GeneratorUserInfo.Generator gen = new GeneratorUserInfo.Generator();
            for (int i = 0; i < 20; i += 3) {
                Person client = new Client() { Id = i, FirstName = gen.getFirstName(), LastName = gen.getLastName(), SecondName = gen.getSecondName(), TelNumber = gen.getPhoneNumber(), Age = gen.getAge() };
                Person driver = new Driver() { Id = i + 1, FirstName = gen.getFirstName(), LastName = gen.getLastName(), SecondName = gen.getSecondName(), TelNumber = gen.getPhoneNumber(), Age = gen.getAge() };
                Person manager = new Manager() { Id = i + 2, FirstName = gen.getFirstName(), LastName = gen.getLastName(), SecondName = gen.getSecondName(), TelNumber = gen.getPhoneNumber(), Age = gen.getAge() };

                dict.Add(new KeyValuePair<int, Person>(client.Id, client));
                dict.Add(new KeyValuePair<int, Person>(driver.Id, driver));
                dict.Add(new KeyValuePair<int, Person>(manager.Id, manager));

            }
            return dict;
        }
    }
}
