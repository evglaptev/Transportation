using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public abstract class Person
    {
        public  int Id { get; set; }
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public  string SecondName { get; set; }
        public  string TelNumber { get; set; }
        public  int Age { get; set; }

        public abstract string Type { get; }
        


 


        //enum type = manager,client, etc.

    }
}
