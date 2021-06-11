using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataAPI.Contexts;
using DataAPI.Models;

namespace DataAPI.Controllers
{
    public class AlgoritmResultsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/AlgoritmResults
        public IQueryable<Algoritm_Results> GetAlgResults([FromUri]int AlgId, [FromUri] int DeviceId, [FromUri] DateTime date)
        {
            DateTime startDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            DateTime finishDate = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);

            return db.AlgResults.Where(d => d.Algoritm_Id == AlgId && d.DeviceId == DeviceId && d.DateTime >= startDate && d.DateTime <= finishDate);
        }

        // GET: api/AlgoritmResults/5
        [ResponseType(typeof(Algoritm_Results))]
        public IHttpActionResult GetAlgoritm_Results(int id)
        {
            Algoritm_Results algoritm_Results = db.AlgResults.Find(id);
            if (algoritm_Results == null)
            {
                return NotFound();
            }

            return Ok(algoritm_Results);
        }

        // PUT: api/AlgoritmResults/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlgoritm_Results(int id, Algoritm_Results algoritm_Results)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != algoritm_Results.Id)
            {
                return BadRequest();
            }

            db.Entry(algoritm_Results).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Algoritm_ResultsExists(id))
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

        // POST: api/AlgoritmResults
        //[ResponseType(typeof(Algoritm_Results))]
        public IQueryable PostAlgoritm_Results(PlanDataForSend obj)
        {
            DateTime startDate = new DateTime(obj.date.Year, obj.date.Month, obj.date.Day, 0, 0, 0);
            DateTime finishDate = new DateTime(obj.date.Year, obj.date.Month, obj.date.Day, 23, 59, 59);

            return db.AlgResults.Where(d => d.Algoritm_Id == obj.AlgId && d.DeviceId == obj.DeviceId && d.DateTime >= startDate && d.DateTime <= finishDate);
        }

        // DELETE: api/AlgoritmResults/5
        [ResponseType(typeof(Algoritm_Results))]
        public IHttpActionResult DeleteAlgoritm_Results(int id)
        {
            Algoritm_Results algoritm_Results = db.AlgResults.Find(id);
            if (algoritm_Results == null)
            {
                return NotFound();
            }

            db.AlgResults.Remove(algoritm_Results);
            db.SaveChanges();

            return Ok(algoritm_Results);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Algoritm_ResultsExists(int id)
        {
            return db.AlgResults.Count(e => e.Id == id) > 0;
        }
    }
}