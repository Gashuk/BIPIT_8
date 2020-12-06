using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Бипит_8
{
    public class RaborContext : DbContext
    {
        public RaborContext() : base("DBConnection") { }

        public DbSet<Rabor> Rabor { get; set; }
    }
}