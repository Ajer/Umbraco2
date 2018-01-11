using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
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

                    Cabins.CreateCabin("House1", "Medborgarvägen 5 Malmö","");

                    Cabins.CreateCabin("House3", "Ystadsvägen 39 Ystads Havsbad","");
                    Cabins.CreateCabin("House5", "Trelleborgsvägen 19 Trelleborg Havsbad","");

                    Cabins.CreateCabin("House11", "Fontana del Traviata 31, Florens,Italien","");
                    Cabins.CreateCabin("House21", "Elysee de Charles de Gaulle 115 , Paris,Frankrike","");

                    Cabins.CreateCabin("House7", "Calle de la vida 102 Marbella, Spanien","");
                    Cabins.CreateCabin("House9", "Calle de la Islas del Canarias 55 Puerto Ingles, Spanien","");

                    Bookings.CreateBooking(new DateTime(2017, 6, 1, 16, 0, 0), new DateTime(2017, 6, 6, 16, 0, 0), 3, 6);
                    Bookings.CreateBooking(new DateTime(2017, 8, 9, 10, 0, 0), new DateTime(2017, 8, 23, 10, 0, 0), 1, 4);
                    Bookings.CreateBooking(new DateTime(2017, 4, 10, 10, 0, 0), new DateTime(2017, 4, 15, 10, 0, 0), 1, 5);

               }
                catch (Exception e)
                {
                    //Console.SetError(e.Message);
                }

                var gs = new Guests();
                Guest g= gs.GetGuest("m.andersson@gmail.com");

                var b = new Bookings();
                List<Booking> h = b.GetAllBookingsForGuest("nils.svensson@hotmail.com");
                


            }
        }
    }

