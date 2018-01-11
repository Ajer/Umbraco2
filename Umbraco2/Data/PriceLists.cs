using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace Umbraco2.Data
{
    public class PriceLists
    {
        public static PriceList CreatePriceLists(int price,DateTime startDateValid, DateTime endDateValid,int cabinId)
        {
            if (!ExistPriceList(startDateValid,endDateValid,cabinId))
            {
                var db = ApplicationContext.Current.DatabaseContext.Database;
             

                var p = new PriceList
                {
                    Price = price,
                    StartDateValid = startDateValid,
                    EndDateValid = endDateValid,
                    CabinId = cabinId
                };

                db.Insert(p);

                return p;
            }
            return null;
        }


        public PriceList GetPriceList(int id)
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var p = db.SingleOrDefault<PriceList>(id);

            if (p != null)
            {
                return p;
            } 
            return null;                        
        }


        public PriceList GetPriceList(DateTime startDateValid, DateTime endDateValid, int cabinId)
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var q = db.Fetch<PriceList>(new Sql()
                .Select("*")
                .From("PriceList").Where("StartDateValid=@0 and EndDateValid=@1 and CabinId=@2", startDateValid, endDateValid, cabinId));

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


        public List<PriceList> GetAllPriceLists()
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var pl = db.Fetch<PriceList>(new Sql()
                .Select("*")
                .From("PriceList"));

             return pl;
        }


        public static bool ExistPriceList(DateTime startDateValid, DateTime endDateValid, int cabinId)
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var pl = db.Fetch<PriceList>(new Sql()
                .Select("Id")
                .From("PriceList").Where("StartDateValid=@0 and EndDateValid=@1 and CabinId=@2", startDateValid, endDateValid, cabinId));

            return (pl.Count != 0);
        }
    }
}