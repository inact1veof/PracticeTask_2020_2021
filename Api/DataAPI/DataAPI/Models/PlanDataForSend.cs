using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAPI.Models
{
    public class PlanDataForSend
    {
        public int AlgId { get; set; }
        public int DeviceId { get; set; }
        public DateTime date { get; set; }
    }
}