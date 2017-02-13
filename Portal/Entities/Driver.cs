using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Entities
{
    public class Driver : Person
    {
        public Driver()
        {
            isFree = true;
        }

        public override string Type
        {
            get
            {
                return this.GetType().ToString();
            }
        }
        public int managerId { get; set; }
        public bool isFree { get; set; } // How to store the data about availability drivers?
    }
}
