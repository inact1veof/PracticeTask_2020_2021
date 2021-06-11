using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Contexts;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PlanController : Controller
    {
        PlanContext db = new PlanContext();
        DeviceDataContext dbDev = new DeviceDataContext();
        // GET: Plan
        public ActionResult Index()
        {            
            IEnumerable<Plan> plans = db.Plans;
            Dictionary<int, string> devices = new Dictionary<int, string>();
            IEnumerable<Device> devicesOutput = dbDev.Devices;
            foreach (Device obj in devicesOutput)
            {
                devices.Add(obj.Id, obj.Name);
            }
            List<OutputPlan> result = new List<OutputPlan>();
            foreach(Plan obj in plans)
            {
                result.Add(new OutputPlan(obj.Id, obj.Date.ToShortDateString(), devices[obj.DeviceId]));
            }
            return View(result);
        }
        [HttpGet]
        public ActionResult CreatePlan()
        {
            ViewBag.Devices = new SelectList(dbDev.Devices, "Id", "Name");
            AlgNames[] reports;
            string baseAddress = "https://localhost:44378/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                response = client.GetAsync("api/AlgoritmNames").Result;
                if (response.IsSuccessStatusCode)
                {
                    reports = response.Content.ReadAsAsync<AlgNames[]>().Result;
                    ViewBag.Algoritms = new SelectList(reports, "Id", "Name");
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult CreatePlan(Plan obj)
        {
            string baseAddress = "https://localhost:44378/";
            Algoritm_Results[] reports;
            db.Plans.Add(obj);
            db.SaveChanges();
            int PlanId = obj.Id;
            PlanDateForSend item = new PlanDateForSend(obj.AlgId, obj.DeviceId, obj.Date);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("api/AlgoritmResults", item).Result;
                if (response.IsSuccessStatusCode)
                {
                    reports = response.Content.ReadAsAsync<Algoritm_Results[]>().Result;
                    for (int i = 0; i < reports.Length; i++)
                    {
                        db.PlanValues.Add(new PlanValues(reports[i].DateTime, reports[i].Value, PlanId));
                    }
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult EditPlan(int? id)
        {
            return View(db.PlanValues.Where(d => d.PlanId == id));
        }
        [HttpGet]
        public ActionResult EditValue(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            PlanValues value = db.PlanValues.Find(id);
            if (value != null)
            {
                return View(value);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditValue(PlanValues obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditPlan", new { id = obj.PlanId});
        }
        public ActionResult DeletePlan(int id)
        {
            var device = db.Plans.FirstOrDefault(f => f.Id == id);
            db.Entry(device).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}