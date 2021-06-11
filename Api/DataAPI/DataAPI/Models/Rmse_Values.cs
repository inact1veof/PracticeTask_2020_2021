using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAPI.Models
{
    public class Rmse_Values
    {
        public int Id { get; set; }
        public int AlgId { get; set; }
        public DateTime Date { get; set; }
        public float Value { get; set; }
        public int DeviceId { get; set; }
    }
}