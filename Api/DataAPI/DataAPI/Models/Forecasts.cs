using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAPI.Models
{
    public class Forecasts
    {
        public int Id { get; set; }
        public int AlgoritmNumb { get; set; }
        public DateTime DateForForecast { get; set; }
        public int ValueId { get; set; }
        public int RealValueId { get; set; }
        public int RmseValueId { get; set; }
        public int DeviceId { get; set; }

    }
}