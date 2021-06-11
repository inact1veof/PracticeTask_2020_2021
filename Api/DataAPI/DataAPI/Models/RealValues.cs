using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAPI.Models
{
    public class RealValues
    {
        public int Id { get; set; }
        public DateTime Date_Time { get; set; }
        public float Value { get; set; }
        public int Device_Id { get; set; }
    }
}