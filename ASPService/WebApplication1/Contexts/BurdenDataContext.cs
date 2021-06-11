using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Contexts
{
    public class BurdenDataContext: DbContext
    {
        public BurdenDataContext() : base("DefaultConnection")
        {

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Burden> Burdens { get; set; }
    }
}