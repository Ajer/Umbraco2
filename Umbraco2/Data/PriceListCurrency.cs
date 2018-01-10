using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;


namespace Umbraco2.Data
{
    [TableName("PriceListCurrency")]
    [PrimaryKey("PriceListId,CabinId")]
    public class PriceListCurrency
    {
        [Column("PriceListId")]
        public int PriceListId { get; set; }

        [Column("CabinId")]
        public int CabinId { get; set; }

    }
}