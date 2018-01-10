using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;


namespace Umbraco2.Data
{
    [PrimaryKey("Id")]
    public class Currency
    {
        [Column("Id")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }


        [Column("Name")]
        public int Name { get; set; }
    }
}