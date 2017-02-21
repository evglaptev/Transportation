using System;
using System.Collections.Generic;
using Portal.Entities;
using Portal.Interfaces;
using System.Linq;

namespace Portal
{
    internal class Clients : IClients
    {
        private IDictionary<int, Client> clientsDictionary;

        public Clients()
        {
            clientsDictionary = new Dictionary<int, Client>();
        }
        public int createPerson(Person person)
        {

            Client tmp = clientsDictionary.Values.Where(p => p.phoneNumber == person.phoneNumber).FirstOrDefault();
            if (tmp == null)
            {
                int maxKey;
                if (clientsDictionary.Count != 0)
                    maxKey = clientsDictionary.Keys.Max();
                else
                    maxKey = 0;

                Client client = (Client)person;
                client.Id = maxKey;
                clientsDictionary.Add(maxKey, client);
                return maxKey;
            }
            throw new Exception("Users wich nonunique phoneNumber ");//TODO when created new Client wich nonunique phoneNumber
        }

        

        public bool delPersonById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> getAllPersons()
        {
            throw new NotImplementedException();
        }

        public Client getByPhoneNumber(string phoneNumber)
        {
            Client tmp;
            try
            {
                 tmp = clientsDictionary.Values.Where(p => p.phoneNumber == phoneNumber).First();
                
            }
            catch (Exception ex)
            {
                tmp = null;
            }
            return tmp;

          
        }

        public Person getPersonById(int id)
        {
            throw new NotImplementedException();
        }
    }
}