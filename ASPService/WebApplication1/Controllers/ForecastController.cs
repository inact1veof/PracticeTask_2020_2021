using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
    [Authorize]
    public class ForecastController : Controller
    {
        DeviceDataContext db = new DeviceDataContext();
        // GET: Forecast
        public ActionResult Index()
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo("grafana-server.exe");
            p.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + @"grafana\bin\";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
            IEnumerable<Device> devices = db.Devices;
            SuperForecasts[] reports;
            string baseAddress = "https://localhost:44378/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;

                response = client.GetAsync("api/SuperForecasts").Result;
                if (response.IsSuccessStatusCode)
                {
                    reports = response.Content.ReadAsAsync<SuperForecasts[]>().Result;
                    ViewBag.Forecasts = reports;
                    foreach (SuperForecasts obj in reports)
                    {
                        Device dev = devices.Where(d => d.Id == obj.DeviceId).FirstOrDefault();
                        obj.DeviceName = dev.Name;
                    }
                    return View(reports);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult CreateForecast()
        {
            IEnumerable<Device> devices = db.Devices;
            ViewBag.Devices = new SelectList(db.Devices, "Id", "Name");
            List<string> Times = new List<string>();
            Times.Add("00:00");
            for (int i = 1; i < 10; i++)
            {
                Times.Add($"0{i}:00");
            }
            for (int i = 10; i < 24; i++)
            {
                Times.Add($"{i}:00");
            }
            ViewBag.Times = new SelectList(Times);
            return View();
        }
        [HttpPost]
        public ActionResult CreateForecast(InputDataForForecast obj)
        {
            string date = obj.Date.ToShortDateString();
            string time = obj.Time;
            string devid = obj.DeviceId.ToString();
            string resultStr = $"{date},{time},{devid}";
            string baseAddress = "https://localhost:44378/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("api/SuperForecasts", resultStr).Result;
            }           
            return RedirectToAction("Index");
        }
        public ActionResult DeleteForecast(int id)
        {
            string baseAddress = "https://localhost:44378/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("api/SuperForecasts/" + id).Result;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Grafana()
        {
            Process.Start("http://localhost:3000/d/NsfdLUeGz/za-mesiats?orgId=1");
            return RedirectToAction("Index");
        }
    }
}