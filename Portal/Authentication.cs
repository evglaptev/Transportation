using Portal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Entities;
using System.Security.Principal;
using System.Web.Security;

namespace Portal
{
    public class Authentication : IAuthentication
    {
        Server serv = Server.getServer();
        private IPrincipal _currentClient;
        public IPrincipal CurrentClient
        {
            get
            {
                if (_currentClient == null)
                {
                    try
                    {
                        HttpCookie authCookie = HttpContext.Request.Cookies.Get("__AUTH_COOKIE");
                        if (authCookie!=null&&(!string.IsNullOrEmpty(authCookie.Value)){
                        var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                            Client client = serv.getClientByName(ticket.Name);
                            new UserProvider();
                            UserIdentity
                        } else
                        //{ _currentClient = null;

                    }
                    catch(Exception ex)
                    {
                        //Message about error authentication.

                    }
                }
                return _currentClient;
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

            // Server serv; serv.login(login,pass) if OK => CreateCookie(userName); return Client

        }

        public Client LogOut()
        {
            throw new NotImplementedException();
        }

        private void CreateCookie(string userName)
        {
            var ticket = new FormsAuthenticationTicket
                (1,
                userName, 
                DateTime.Now, 
                DateTime.Now.Add(FormsAuthentication.Timeout), 
                true, 
                string.Empty, 
                FormsAuthentication.FormsCookiePath);
            var encTicket = FormsAuthentication.Encrypt(ticket);

            HttpCookie AuthCookie = new HttpCookie("__AUTH_COOKIE")
            {
                Value = encTicket,
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
            };
            HttpContext.Response.Cookies.Set(AuthCookie);
        }


    

    internal class UserIndentity : IIdentity
    {
        public Client client { get; set; }
        public string AuthenticationType
        {
            get
            {
                return typeof(Client).ToString();
            }
        }
            public bool IsAuthenticated
            {
                get
                {
                    return client != null ? true : false;
                }
            }

            public string Name
            {
                get
                {
                    if (client != null) return client.Id.ToString();
                    return "Anonym";
                }
            }
        }



        public class UserProvider : IPrincipal
        {
            private UserIndentity userIndentity { get; set; }
            public IIdentity Identity
            {
                get
                {
                    return userIndentity;
                }
            }

            public bool IsInRole(string role)
            {
                if (userIndentity == null)
                {
                    return false;
                }
                return true;//userIndentity.Client.InRoles(role);  Client to has method wich return true/false for role string parameter.
            }
        }

    }
}