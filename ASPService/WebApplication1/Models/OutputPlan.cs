using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class OutputPlan
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Device { get; set; }
        public OutputPlan(int id, string dt, string dev)
        {
            Id = id;
            Date = dt;
            Device = dev;
        }
    }
}