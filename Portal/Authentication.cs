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
        private IPrincipal _currentClient
        public IPrincipal CurrentClient
        {
            get
            {
                if (_currentClient == null)
                {
                    try
                    {
                        HttpCookie authCookie = HttpContext.Request.Cookies.Get("__AUTH_COOKIE");
                        //if authCookie!=null and cookie.value is not empty or null{
                        var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                        //serv.getClientByName(ticket.Name)

                        //} else
                        //{ _currentClient = null;

                    }
                    catch(Exception ex)
                    {
                        //Message about error authentication.

                    }
                }
                return _currentClient;
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


    }
}