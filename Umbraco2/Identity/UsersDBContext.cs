using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Umbraco2.Identity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    

        public class UsersDBContext : IdentityDbContext<User>
        {
            public UsersDBContext() : base("UsersDB")
            {
                Database.SetInitializer<UsersDBContext>(new UsersDBInitializer());
                this.Configuration.LazyLoadingEnabled = false;
            }

            public static UsersDBContext Create()
            {
                return new UsersDBContext();
            }

        }
    }


