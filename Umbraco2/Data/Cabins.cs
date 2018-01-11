using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace Umbraco2.Data
{
    public class Cabins
    {
        public static Cabin CreateCabin(string name, string address,string description)
        {
            if (!ExistCabin(name,address))
            {
                var db = ApplicationContext.Current.DatabaseContext.Database;

                var c = new Cabin
                {
                    Name = name,
                    Address = address,
                    Description = description
                    
                };

                db.Insert(c);

                return c;
            }
            return null;
        }


        public Cabin GetCabin(int id)
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var c = db.SingleOrDefault<Cabin>(id);

            if (c != null)
            {
                return c;
            }

            return null;
        }


        public Cabin GetCabin(string name, string address)
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var q = db.Fetch<Cabin>(new Sql()
                .Select("*")
                .From("Cabin").Where("Name=@0 and Address=@1", name, address));

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



        public List<Cabin> GetAllCabins()
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var sql = db.Fetch<Cabin>(new Sql()
                .Select("*")
                .From("Cabin"));

               //var g = db.Page<Guest>(page,itemsPerPage,sql);
            return sql;
        }

        public static bool ExistCabin(string name, string address)
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var sql = db.Fetch<Cabin>(new Sql()
                .Select("Id")
                .From("Cabin").Where("Name=@0 and Address=@1",name,address));
            return (sql.Count != 0);
        }


    }
}