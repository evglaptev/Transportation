using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Client : Person
    {
        public override string Type
        {
            get
            {
                return this.GetType().ToString();
            }
        }



    }
}
