using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Managers : Persons, IManagers
    {
        //  public Managers(IDictionary<int, Person> dict) : base(dict) { }
        public Managers(IDictionary<int, Person> personsDictionary) : base(personsDictionary)
        {
        }

        public IDictionary<int, Manager> managersDictionary;
    }
}
