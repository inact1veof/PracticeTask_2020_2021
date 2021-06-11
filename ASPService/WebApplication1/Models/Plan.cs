using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int AlgId { get; set; }
        public int DeviceId { get; set; }
    }
}