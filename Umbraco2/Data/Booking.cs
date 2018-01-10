using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;


namespace Umbraco2.Data
{
    [PrimaryKey("Id")]
    public class Booking
    {
            
        [Column("Id")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }


        [Column("DateStart")]
        public DateTime DateStart{ get; set; }

        [Column("DateEnd")]
        public DateTime DateEnd { get; set; }

        [Column("GuestId")]
        public int GuestId { get; set; }


        [Column("CabinId")]
        public int CabinId { get; set; }

        //[NullSetting(NullSetting = NullSettings.Null)]
        //[SpecialDbType(SpecialDbTypes.NTEXT)]     

    }
 }