using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Contexts;
using WebApplication1.Models;
using Microsoft.AspNet.Identity;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        UserDataContext db = new UserDataContext();
        // GET: User
        public ActionResult Index()
        {

            IEnumerable<AspNetUser> users = db.Users;
            IEnumerable<Company> companies = db.Companies;
            IEnumerable<Departament> departaments = db.Departaments;
            IEnumerable<Position> positions = db.Positions;
            Dictionary<int, string> cmp = new Dictionary<int, string>();
            foreach (Company camp in companies)
            {
                cmp.Add(camp.Id, camp.Name);
            }
            Dictionary<int, string> dp = new Dictionary<int, string>();
            foreach (Departament camp in departaments)
            {
                dp.Add(camp.Id, camp.Name);
            }
            Dictionary<int, string> pos = new Dictionary<int, string>();
            foreach (Position camp in positions)
            {
                pos.Add(camp.Id, camp.Name);
            }
            List<SuperUser> result = new List<SuperUser>();
            foreach (AspNetUser us in users)
            {
                result.Add(new SuperUser(us.Id, us.Email, us.BirthDate, cmp[us.CompanyId], dp[us.DepartamentId], pos[us.PositionId], us.Name, us.Surname));
            }
            return View(result);
        }
        [HttpGet]
        public ActionResult EditUser(string id)
        {
            ViewBag.Companies = new SelectList(db.Companies, "Id", "Name");
            ViewBag.Departaments = new SelectList(db.Departaments, "Id", "Name");
            ViewBag.Positions = new SelectList(db.Positions, "Id", "Name");
            if (id == null)
            {
                return HttpNotFound();
            }
            AspNetUser device = db.Users.Find(id);
            if (device != null)
            {
                return View(device);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditUser(AspNetUser obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteUser(string id)
        {
            string idLogin = User.Identity.GetUserId();
            if (id.Equals(idLogin))
            {
                return RedirectToAction("Index");
            }
            else
            {
                var device = db.Users.FirstOrDefault(f => f.Id == id);
                db.Entry(device).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult CreateUser()
        {
            return RedirectToAction("Register", "Account");
        }
    }
}