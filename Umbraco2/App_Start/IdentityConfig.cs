using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Umbraco2.Identity;

[assembly: OwinStartup(typeof(Umbraco2.IdentityConfig))]
namespace Umbraco2
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            //app.CreatePerOwinContext<UsersDBContext>(UsersDBContext.Create);

            //app.CreatePerOwinContext<UsersManager>(UsersManager.Create);
            //app.CreatePerOwinContext<UserRoleManager>(UserRoleManager.Create);

            //app.UseCookieAuthentication(new CookieAuthenticationOptions{
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie        
          //  });
        }
    }
}