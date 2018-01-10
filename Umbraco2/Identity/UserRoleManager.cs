using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;

namespace  Umbraco2.Identity
{
    public class UserRoleManager : RoleManager<Role>
    {
        public UserRoleManager(RoleStore<Role>  store):base(store)
        {
        }


        public static UserRoleManager Create(IdentityFactoryOptions<UserRoleManager> op,IOwinContext context)
        {
            return new UserRoleManager(new RoleStore<Role>(context.Get<UsersDBContext>()));
        }


    }
}