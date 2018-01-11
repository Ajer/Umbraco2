using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace Umbraco2.Data
{
    public class PriceListCurrencies
    {
        public static PriceListCurrency CreatePriceListCurrencies(int priceListId,int currencyId)
        {
            if (!ExistPriceListCurrency(priceListId, currencyId))
            {
                var db = ApplicationContext.Current.DatabaseContext.Database;

                var c = new PriceListCurrency
                {
                   PriceListId = priceListId,
                   CurrencyId = currencyId
                };

                db.Insert(c);

                return c;
            }
            return null;
        }


        public PriceListCurrency GetPriceListCurrency(int priceListId,int currencyId)
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var plc = db.SingleOrDefault<PriceListCurrency>(currencyId);

            if (plc != null)
            {
                return plc;
            }
            return null;
        }



        public List<PriceListCurrency> GetAllCurrencies()
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var pl = db.Fetch<PriceListCurrency>(new Sql()
                .Select("*")
                .From("PriceList"));

            return pl;
        }


        public static bool ExistPriceListCurrency(int priceListId, int currencyId)
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var pl = db.Fetch<PriceListCurrency>(new Sql()
                .Select("*")
                .From("PriceListCurrency").Where("PriceListId=@0 and CurrencyId=@1",priceListId,currencyId));

            return (pl.Count != 0);
        }
    }
}
