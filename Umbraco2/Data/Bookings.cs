using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace Umbraco2.Data
{
    public class Bookings
    {
        public static Booking CreateBooking(DateTime startDateTime, DateTime endDateTime,int guestId,int cabinId)
        {
            if (!ExistBooking(startDateTime,endDateTime,guestId,cabinId))
            {
                var db = ApplicationContext.Current.DatabaseContext.Database;

                var c = new Booking
                {
                   DateStart = startDateTime,
                   DateEnd = endDateTime,
                   GuestId = guestId,
                   CabinId = cabinId
                };

                db.Insert(c);
   
                return c;
            }
            return null;
        }


        public Booking GetBooking(int id)
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var c = db.SingleOrDefault<Booking>(id);

            if (c != null)
            {
                return c;
            }

            return null;
        }


        public Booking GetBooking(DateTime startDateTime, DateTime endDateTime, int guestId, int cabinId)
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var q = db.Fetch<Booking>(new Sql()
                .Select("*")
                .From("Booking").Where("DateStart=@0 and DateEnd=@1 and GuestId=@2 and CabinId=@3",startDateTime, endDateTime, guestId, cabinId));

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



        public List<Booking> GetAllBookings()
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var sql = db.Fetch<Booking>(new Sql()
                .Select("*")
                .From("Booking"));

            //var g = db.Page<Guest>(page,itemsPerPage,sql);
            return sql;
        }

        public  List<Booking> GetAllBookingsForGuest(string guestEmail)
        {
            //guestEmail = guestEmail.Insert(guestEmail.IndexOf("@") + 1, "@");

            var db = ApplicationContext.Current.DatabaseContext.Database;
            var sql = "select * from Booking b inner join Guest g on b.GuestId=g.Id and g.Email=@0";
            var q = db.Query<Booking>(sql, guestEmail);

            return q.ToList();

            //Equivalent:
            //var sql = Sql.Builder
            //    .Select("*")
            //    .From("Booking b")
            //    .InnerJoin("Guest g").On("b.GuestId = g.Id and g.email=@0", guestEmail);
            //var q = db.Query<Booking>(sql);
            //return q;   // returntype: IEnumerable<Booking>  ,  q.ToList()
        }

        public static bool ExistBooking(DateTime startDateTime, DateTime endDateTime, int guestId, int cabinId)
        {
            var db = ApplicationContext.Current.DatabaseContext.Database;
            var q = db.Fetch<Booking>(new Sql()
                .Select("*")
                .From("Booking").Where("DateStart=@0 and DateEnd=@1 and GuestId=@2 and CabinId=@3", startDateTime, endDateTime, guestId, cabinId));
            return (q.Count != 0);
        }
    }
}