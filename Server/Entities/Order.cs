using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public string DateTime { get; set; }
    }
}
