using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CycleProvider.MvcApp.Models
{
    public class CompaniesDb : DbContext
    {
        public CompaniesDb() : base("name=CompaniesDb")
        {
        }

        public DbSet<Companies> Companies { get; set; }
    }
}
