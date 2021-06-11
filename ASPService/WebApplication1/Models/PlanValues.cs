using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PlanValues
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public float Value { get; set; }
        public int PlanId { get; set; }
        public PlanValues(DateTime dt, float val, int plid)
        {
            DateTime = dt;
            Value = val;
            PlanId = plid;
        }
        public PlanValues()
        {

        }
    }
}