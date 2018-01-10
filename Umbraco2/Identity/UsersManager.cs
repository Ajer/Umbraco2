using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;


namespace Umbraco2.Identity
{
    public class UsersManager:UserManager<User>
    {
        public UsersManager(IUserStore<User> store):base(store)
        {
        }


        public static UsersManager Create(IdentityFactoryOptions<UsersManager> op,IOwinContext context)
        {
            UsersDBContext uc =  context.Get<UsersDBContext>();
            UsersManager um = new UsersManager(new UserStore<User>(uc));

            return um;
        }
    }
}