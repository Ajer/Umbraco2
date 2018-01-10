using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbraco2.Data
{
    public class cabins
    {
        public static Guest CreateCabin(string firstname,string lastname,string email)
        {
            var g = new Guest
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email
            };
            return g;
        }

        
    }
}