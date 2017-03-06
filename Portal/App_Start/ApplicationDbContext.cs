using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace Portal
{
    internal class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        ApplicationDbContext() : base("AuthConnection") { }

        internal static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class ApplicationUser:IdentityUser
    {

        internal async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}