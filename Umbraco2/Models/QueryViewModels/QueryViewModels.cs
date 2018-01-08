using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbraco2.Models.QueryViewModels   // ViewModels created for a certain databasequery
{
    public class GetNbrOfQVM
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int NbrOf { get; set; }

    }
}