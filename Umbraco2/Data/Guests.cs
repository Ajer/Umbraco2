using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace Umbraco2.Data
{
    public class Guests
    {
        public static Guest CreateGuest(string firstname,string lastname,string email)
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;

            var g = new Guest
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email
            };

            db.Insert(g);

            return g;
        }

        public Guest GetGuest(int id)
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var g = db.SingleOrDefault<Guest>(id);

            if (g != null)
            {
                return g;
            }
      
            return null;                        
        }


        public Guest GetGuest(string email)
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var q = db.Fetch<Guest>(new Sql()
                .Select("*")
                .From("Guest").Where("Email=@0",email));

            if (q != null)
            {
                if (q.Count == 1)
                {
                    return q[0];
                }           
                return null;               
            }
            return null;            
        }



        public List<Guest> GetAllGuests()
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var sql = db.Fetch<Guest>(new Sql()
                .Select("*")
                .From("Guest"));

             //var g = db.Page<Guest>(page,itemsPerPage,sql);

             return sql;
        }
    }
}