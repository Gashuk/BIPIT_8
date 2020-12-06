using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Бипит_8
{
    public class Vid_rabotContext : DbContext
    {
        public Vid_rabotContext() : base("DBConnection") { }

        public DbSet<Vid_rabot> Vid_rabot { get; set; }
    }
}