using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Entities
{
    public class Order
    {

        public int OrderId { get; set; }
        public int ClientId { get; set; }

        public int DriverId { get; set; }
        [DisplayName("Адрес подачи автомобиля: ")]
        public string AddressFrom { get; set; }
        [DisplayName("Адрес доставки: ")]
        public string AddressTo { get; set; }
        [DisplayName("Дата и время подачи автомобиля")]
        public string DateTime { get; set; }
        public int ManagerId { get; internal set; }
    }
}
