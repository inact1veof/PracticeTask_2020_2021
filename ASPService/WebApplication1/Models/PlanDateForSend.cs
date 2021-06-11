using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PlanDateForSend
    {
        public int AlgId { get; set; }
        public int DeviceId { get; set; }
        public DateTime date { get; set; }
        public PlanDateForSend(int algid, int devid, DateTime dt)
        {
            AlgId = algid;
            DeviceId = devid;
            date = dt;
        }
    }
}