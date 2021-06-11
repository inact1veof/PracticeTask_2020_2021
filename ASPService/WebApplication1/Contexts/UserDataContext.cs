using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Contexts
{
    public class UserDataContext: DbContext
    {
        public UserDataContext() : base("DefaultConnection")
        {

        }
        public DbSet<AspNetUser> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}