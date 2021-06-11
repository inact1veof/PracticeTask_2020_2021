using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class SuperUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string Company { get; set; }
        public string Departament { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public SuperUser(string id,string mail, DateTime bd, string cmp, string dep, string pos, string name, string sn)
        {
            Id = id;
            Email = mail;
            BirthDate = bd.ToShortDateString();
            Company = cmp;
            Departament = dep;
            Position = pos;
            Name = name;
            Surname = sn;
        }
    }
}