using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Manager : Person
    {
        public override string Type
        {
            get
            {
                return this.GetType().ToString();
            }
        }

        public IList<int> clientsId { get; set; }
        public IList<int> driversId { get; set; }

        public Manager()
        {
            driversId = new List<int>();
            clientsId = new List<int>();
        }


    }
}
