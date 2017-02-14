using Portal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Entities;
using System.Security.Principal;

namespace Portal
{
    public class Authentication : IAuthentication
    {
        public IPrincipal CurrentClient
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public HttpContext HttpContext
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Client Login(string login, string password)
        {
            throw new NotImplementedException();
        }

        public Client LogOut()
        {
            throw new NotImplementedException();
        }
    }
}