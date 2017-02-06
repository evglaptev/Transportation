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

        public IList<int> driversId;

        public Manager()
        {
            driversId = new List<int>();
        }

        public Manager(params int[] value)
        {
            driversId = new List<int>();
            foreach (var e in value)
            {
                driversId.Add(e);
            }

        }
    }
}
