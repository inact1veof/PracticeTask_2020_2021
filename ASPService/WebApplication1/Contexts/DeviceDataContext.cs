using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Contexts
{
    public class DeviceDataContext: DbContext
    {
        public DeviceDataContext() : base("DefaultConnection")
        {

        }
        public DbSet<Burden> Burdens { get; set; }
        public DbSet<Device> Devices { get; set; }

        public DbSet<RealValue> RealValues { get; set; }
    }
}