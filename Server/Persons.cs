using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    abstract class Persons : IPersons
    {
        public IDictionary<int, Person> personsDictionary { get; set; }

        public Persons(IDictionary<int, Person> personsDictionary)
        {
            this.personsDictionary = personsDictionary;
        }

        public Person getPersonById(int id)
        {
            Person person;
            personsDictionary.TryGetValue(id, out person);
            return person;
        }
        public IEnumerable<Person> getAllPersons()
        {

            return personsDictionary.Values.AsEnumerable();
        }
        public int createPerson(Person person)
        {
            int key = personsDictionary.Keys.Max() + 1;
            person.Id = key;
            personsDictionary.Add(key, person);
            return key;
        }

        public bool delPersonById(int id)
        {
            return personsDictionary.Remove(id);
        }

    }
}
