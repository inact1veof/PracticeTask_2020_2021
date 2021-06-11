using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class InputDataForForecast
    {
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int DeviceId { get; set; }
    }
}