using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Entities
{
   public class Client : Person
    {
        public override string Type
        {
            get
            {
                return this.GetType().ToString();
            }
        }

        public int managerId { get; set; }



    }
}
