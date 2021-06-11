using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RealValue
    {
        public int Id { get; set; }
        public DateTime Date_Time { get; set; }
        public float Value { get; set; }
        public int Device_Id { get; set; }

        public RealValue()
        {
            Id = 0;
            Date_Time = default;
            Value = 0;
            Device_Id = 0;
        }

        public RealValue(DateTime dt, float val, int devId)
        {
            Date_Time = dt;
            Value = val;
            Device_Id = devId;
        }
    }
}