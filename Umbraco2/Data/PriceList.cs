using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;


namespace Umbraco2.Data
{
    [PrimaryKey("Id", autoIncrement = true)]
    public class PriceList
    {
        [Column("Id")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }

        [Column("Price")]
        public int Price { get; set; }

        [Column("StartDateValid")]
        public DateTime StartDateValid { get; set; }

        [Column("EndDateValid")]
        public DateTime EndDateValid { get; set; }

        [Column("CabinId")]
        public int CabinId { get; set; }
    }
}
