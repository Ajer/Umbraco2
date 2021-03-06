﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace Umbraco2.Data
{
    public class Currencies
    {
        public static Currency CreateCurrencies(string name,string isoCode)
        {
            if (!ExistCurrency(name,isoCode))
            {
                var db = ApplicationContext.Current.DatabaseContext.Database;

                var c = new Currency
                {
                    Name = name,
                    IsoCode = isoCode
                };

                db.Insert(c);

                return c;
            }
            return null;
        }


        public Currency GetCurrency(int id)
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var c = db.SingleOrDefault<Currency>(id);

            if (c != null)
            {
                return c;
            }
            return null;
        }



        public List<Currency> GetAllCurrencies()
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var pl = db.Fetch<Currency>(new Sql()
                .Select("*")
                .From("PriceList"));

            return pl;
        }


        public static bool ExistCurrency(string name,string isoCode)
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var pl = db.Fetch<Guest>(new Sql()
                .Select("Id")
                .From("Currency").Where("Name=@0 and IsoCode=@1",name,isoCode));

            return (pl.Count != 0);
        }
    }
}
