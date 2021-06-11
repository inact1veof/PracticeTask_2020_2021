using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Contexts;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class BurdenController : Controller
    {
        BurdenDataContext db = new BurdenDataContext();
        public ActionResult Index()
        {
            IEnumerable<Burden> burdens = db.Burdens;

            var company = db.Companies.FirstOrDefault();
            ViewBag.CompanyName = company.Name;
            return View(burdens);
        }
        [HttpGet]
        public ActionResult EditBurden(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Burden burden = db.Burdens.Find(id);
            if (burden != null)
            {
                return View(burden);
            }
            return HttpNotFound();

        }
        [HttpPost]
        public ActionResult EditBurden(Burden obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBurden(int id)
        {
            var burden = db.Burdens.FirstOrDefault(f => f.Id == id);
            db.Entry(burden).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateBurden()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBurden(Burden obj)
        {
            obj.Company_Id = 1;
            db.Burdens.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}