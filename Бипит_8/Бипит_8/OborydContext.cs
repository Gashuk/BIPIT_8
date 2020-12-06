using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Бипит_8
{
    public class OborydContext : DbContext
    {
        public OborydContext() : base("DBConnection") { }

        public DbSet<Oboryd> Oboryd { get; set; }
    }
}