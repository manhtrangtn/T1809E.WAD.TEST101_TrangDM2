using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace T1809E.WAD.TEST101_TrangDM2.Models
{
    public class DatabaseContext: DbContext
    {
      public DatabaseContext() : base("ConnectionString") { }
      public DbSet<Penalty> Penalties { get; set; }
    }
}