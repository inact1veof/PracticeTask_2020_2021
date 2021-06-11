using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AspNetUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int CompanyId { get; set; }
        public int DepartamentId { get; set; }
        public int PositionId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}