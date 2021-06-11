using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Algoritm_Results
    {
        public int Id { get; set; }
        public int Algoritm_Id { get; set; }
        public DateTime DateTime { get; set; }
        public float Value { get; set; }
        public int DeviceId { get; set; }
    }
}