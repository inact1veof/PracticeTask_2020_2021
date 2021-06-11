using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Contexts
{
    public class PlanContext: DbContext
    {
        public PlanContext() : base("DefaultConnection")
        {

        }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanValues> PlanValues { get; set; }
    }
}