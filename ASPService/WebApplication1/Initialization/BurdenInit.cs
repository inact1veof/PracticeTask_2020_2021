using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Contexts;
using WebApplication1.Models;

namespace WebApplication1.Initialization
{
    public class BurdenInit: DropCreateDatabaseAlways<BurdenDataContext>
    {
        protected override void Seed(BurdenDataContext db)
        {
            db.Burdens.Add(new Burden {Id = 1, Name = "Нагрузка 1", Company_Id = 1 });
            db.Burdens.Add(new Burden { Id = 2, Name = "Нагрузка 2", Company_Id = 1 });
            db.Burdens.Add(new Burden { Id = 3, Name = "Нагрузка 3", Company_Id = 1 });
            base.Seed(db);
        }
    }
}