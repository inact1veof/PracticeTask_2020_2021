using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
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
        public string DeviceName { get; set; }

        public SuperForecasts(string alg, DateTime dt, float val, int realval, float rmseval, int dev)
        {
            Algoritm = alg;
            DateForForecast = dt;
            Value = val;
            RealValueId = realval;
            RmseValue = rmseval;
            DeviceId = dev;
        }
        public SuperForecasts()
        {
            
        }
    }
}