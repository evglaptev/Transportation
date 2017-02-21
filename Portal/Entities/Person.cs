using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Entities
{
    public abstract class Person
    {
        public  int Id { get; set; }
        [DisplayName("Имя: ")]
        public  string FirstName { get; set; }
        [DisplayName("Фамилия: ")]
        public  string LastName { get; set; }
        [DisplayName("Отчество: ")]
        public  string SecondName { get; set; }
        [DisplayName("Номер телефона: ")]
        public  string phoneNumber { get; set; }
        [DisplayName("Пароль: ")]
        public string Password { get; set; }

        public abstract string Type { get; }





        //enum type = manager,client, etc.

    }
}
