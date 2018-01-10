using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Umbraco2.Identity
{
    public class Role:IdentityRole
    {
        public Role() : base()
        {
            
        }

        public Role(String name) : base(name)
        {

        }

    }
}