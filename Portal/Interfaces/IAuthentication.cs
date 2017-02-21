using Portal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Portal.Interfaces
{
    public interface IAuthentication
    {
        IPrincipal CurrentClient { get; }
        HttpContext HttpContext { get; set; }
        Client Login(string login, string password);
        Client LogOut(); 
    }
}
