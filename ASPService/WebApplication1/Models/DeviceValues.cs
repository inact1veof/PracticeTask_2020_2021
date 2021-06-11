using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DeviceValues
    {
        public Device device { get; set; }
        public List<RealValue> value { get; set; }

        public int CountValues { get; set; }
    }
}