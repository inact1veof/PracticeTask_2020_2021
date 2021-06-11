using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class OutputDevice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Burden_Name { get; set; }

        public int Burden_Id { get; set; }

        public OutputDevice(int id, string name, string bname, int bid)
        {
            Id = id;
            Name = name;
            Burden_Name = bname;
            Burden_Id = bid;
        }
    }
}