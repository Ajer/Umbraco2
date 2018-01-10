using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Persistence;
using Umbraco2.Data;

namespace Umbraco2
{
 
        public class RegisterEvents : ApplicationEventHandler
        {
            protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
            {
                //var db = applicationContext.DatabaseContext.Database;

                var logger = LoggerResolver.Current.Logger;
                var dbContext = ApplicationContext.Current.DatabaseContext;
                var helper = new DatabaseSchemaHelper(dbContext.Database, logger, dbContext.SqlSyntax);

                if (!helper.TableExist("Guest"))
                {
                    helper.CreateTable<Guest>(false);
                }

                if (!helper.TableExist("Cabin"))
                {
                    helper.CreateTable<Cabin>(false);
                }

                if (!helper.TableExist("Booking"))
                {
                    helper.CreateTable<Booking>(false);
                }

               if (!helper.TableExist("Currency"))
               {
                  helper.CreateTable<Currency>(false);
               }

                if (!helper.TableExist("PriceList"))
                {
                    helper.CreateTable<PriceList>(false);
                }

                if (!helper.TableExist("PriceListCurrency"))
                {                
                    helper.CreateTable<PriceListCurrency>(false);
                }

                try
                {
                    Guests.CreateGuest("Nils", "Svensson", "nils.svensson@hotmail.com");
                    Guests.CreateGuest("Maja", "Andersson", "m.andersson@gmail.com");
                    Guests.CreateGuest("Gunnar", "Karlsson", "gunnar.karlsson@gmail.com");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                var gs = new Guests();
                Guest g= gs.GetGuest("m.andersson@gmail.com");

            }
        }
    }

