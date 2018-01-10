using System.Data.Entity;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace Umbraco2.Identity
{
    public class UsersDBInitializer : CreateDatabaseIfNotExists<UsersDBContext>
    {
        protected override void Seed(UsersDBContext context)
        {

            UsersManager um = new UsersManager(new UserStore<User>(context));
            UserRoleManager urm = new UserRoleManager(new RoleStore<Role>(context));

            string roleName = "Administrators";
            string userName = "Admin";
            string password = "secret22";
            string email = "admin@example.com";
            //seedHelper(sum, srm, roleName, userName, password, email);

            //string role = "MachineRole";
            //string user = "mach";
            //string pass = "mach_xyz";
            //string e = "mach@example.com";
            //seedHelper(sum, srm, role, user, pass, e);

            if (!urm.RoleExists(roleName))
            {

                urm.Create(new Role(roleName));
            }

            User user = um.FindByName(userName);

            if (user == null)
            {
                um.Create(new User { UserName = userName, Email = email }, password);
                user = um.FindByName(userName);
            }

            if (!um.IsInRole(user.Id, roleName))
            {
                um.AddToRole(user.Id, roleName);
            }


            base.Seed(context);
            //context.SaveChanges();
        }



        //private void seedHelper(UserManager sum,RoleManager srm,string roleName,string userName,string password,string email)
        //{
        //    if (!srm.RoleExists(roleName))
        //    {

        //        srm.Create(new StoreRole(roleName));
        //    }

        //    StoreUser user = sum.FindByName(userName);

        //    if (user == null)
        //    {
        //        sum.Create(new StoreUser { UserName = userName, Email = email }, password);
        //        user = sum.FindByName(userName);
        //    }

        //    if (!sum.IsInRole(user.Id, roleName))
        //    {
        //        sum.AddToRole(user.Id, roleName);
        //    }
        //}

    }

    //internal sealed class Configuration : DbMigrationsConfiguration<StoreIdentityDBContext>
    //{
    //    public Configuration()
    //    {
    //        AutomaticMigrationsEnabled = false;
    //    }
    //}
}