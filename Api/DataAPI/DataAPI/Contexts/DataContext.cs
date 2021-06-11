using DataAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataAPI.Contexts
{
    public class DataContext: DbContext
    {
    public DataContext() : base("ForecastData")
    {

    }
    public DbSet<Forecasts> Forecasts { get; set; }
        public DbSet<Algoritm_Names> AglNames { get; set; }
        public DbSet<Algoritm_Results> AlgResults { get; set; }
        public DbSet<Rmse_Values> RmseValues { get; set; }
        public DbSet<RealValues> RealValues { get; set; }
        public DbSet<Devices> Devices { get; set; }

        public System.Data.Entity.DbSet<DataAPI.Models.SuperForecasts> SuperForecasts { get; set; }
    }
}