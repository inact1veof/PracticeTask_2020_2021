using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using DataAPI.Contexts;

namespace DataAPI.Models
{
    public class SuperForecastsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/SuperForecasts
        public IQueryable<SuperForecasts> GetSuperForecasts()
        {
            IEnumerable<Forecasts> forecasts = db.Forecasts;
            List<Forecasts> forecastsList = new List<Forecasts>();
            List<float> algoritm_ResultsList = new List<float>();
            List<string> algoritm_NamesList = new List<string>();
            List<float> rmse_ValuesList = new List<float>();
            foreach (Forecasts fc in forecasts)
            {
                forecastsList.Add(fc);
            }
            foreach(Forecasts fc in forecastsList)
            {
                rmse_ValuesList.Add(db.RmseValues.FirstOrDefault(item => item.Id == fc.RmseValueId).Value);
                algoritm_NamesList.Add(db.AglNames.FirstOrDefault(item => item.Id == fc.AlgoritmNumb).Name);
                algoritm_ResultsList.Add(db.AlgResults.FirstOrDefault(item => item.Id == fc.ValueId).Value);
            }
            List<SuperForecasts> result = new List<SuperForecasts>();
            int i = 0;
            foreach(Forecasts obj in forecastsList)
            {
                result.Add(new SuperForecasts(obj.Id, algoritm_NamesList[i], obj.DateForForecast, algoritm_ResultsList[i], obj.RealValueId, rmse_ValuesList[i], obj.DeviceId));
                i++;
            }
            var quer = result.AsQueryable();
            return quer;
        }

        // GET: api/SuperForecasts/5
        [ResponseType(typeof(SuperForecasts))]
        public IHttpActionResult GetSuperForecasts(int id)
        {
            SuperForecasts superForecasts = db.SuperForecasts.Find(id);
            if (superForecasts == null)
            {
                return NotFound();
            }

            return Ok(superForecasts);
        }

        // PUT: api/SuperForecasts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuperForecasts(int id, SuperForecasts superForecasts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != superForecasts.Id)
            {
                return BadRequest();
            }

            db.Entry(superForecasts).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuperForecastsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SuperForecasts
        //[ResponseType(typeof(SuperForecasts))]
        public IHttpActionResult PostSuperForecasts([FromBody]string message)
        {
            int port = 8686;
            string address = "127.0.0.1";
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipPoint);
            byte[] data = Encoding.Unicode.GetBytes(message);
            socket.Send(data);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/SuperForecasts/5
        //[ResponseType(typeof(SuperForecasts))]
        public IHttpActionResult DeleteSuperForecasts(int id)
        {
            Forecasts superForecasts = db.Forecasts.Find(id);
            if (superForecasts == null)
            {
                return NotFound();
            }

            db.Forecasts.Remove(superForecasts);
            db.SaveChanges();

            return Ok(superForecasts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuperForecastsExists(int id)
        {
            return db.SuperForecasts.Count(e => e.Id == id) > 0;
        }
    }
}