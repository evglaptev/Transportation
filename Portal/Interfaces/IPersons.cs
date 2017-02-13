using Portal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Interfaces
{
    interface IPersons
    {
        Person getPersonById(int id);
        IEnumerable<Person> getAllPersons();
        int createPerson(Person person);
        bool delPersonById(int id);
    }
}
