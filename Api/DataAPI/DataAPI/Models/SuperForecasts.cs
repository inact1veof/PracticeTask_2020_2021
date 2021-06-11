using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAPI.Models
{
    public class SuperForecasts
    {
        public int Id { get; set; }
        public string Algoritm { get; set; }
        public DateTime DateForForecast { get; set; }
        public float Value { get; set; }
        public int RealValueId { get; set; }
        public float RmseValue { get; set; }
        public int DeviceId { get; set; }

        public SuperForecasts(int id, string alg, DateTime dt, float val, int realval, float rmseval, int dev)
        {
            Id = id;
            Algoritm = alg;
            DateForForecast = dt;
            Value = val;
            RealValueId = realval;
            RmseValue = rmseval;
            DeviceId = dev;
        }
    }
}