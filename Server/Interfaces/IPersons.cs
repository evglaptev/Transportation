using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    interface IPersons
    {
        Person getPersonById(int id);
        IEnumerable<Person> getAllPersons();
        int createPerson(Person human);
        bool delPersonById(int id);
    }
}
