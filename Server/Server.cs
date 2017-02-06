using Server.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        IManagers Managers { get; set; }
        IDrivers Drivers { get; set; }
        IClients Clients { get; set; }

        IDictionary<int, Person> context = DbContext.getDictionaryPerson();


        public Server()
        {
            Managers = new Managers(context);
        }

        IEnumerable<Manager> getAllManagers()
        {
            return (IEnumerable<Manager>)Managers.getAllPersons();
        }

        //ITasks Tasks { get; set; }
    }
}
