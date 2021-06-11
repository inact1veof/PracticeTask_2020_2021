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
    public class AlgoritmNamesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/AlgoritmNames
        public IQueryable<Algoritm_Names> GetAglNames()
        {
            return db.AglNames;
        }

        // GET: api/AlgoritmNames/5
        [ResponseType(typeof(Algoritm_Names))]
        public IHttpActionResult GetAlgoritm_Names(int id)
        {
            Algoritm_Names algoritm_Names = db.AglNames.Find(id);
            if (algoritm_Names == null)
            {
                return NotFound();
            }

            return Ok(algoritm_Names);
        }

        // PUT: api/AlgoritmNames/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlgoritm_Names(int id, Algoritm_Names algoritm_Names)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != algoritm_Names.Id)
            {
                return BadRequest();
            }

            db.Entry(algoritm_Names).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Algoritm_NamesExists(id))
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

        // POST: api/AlgoritmNames
        [ResponseType(typeof(Algoritm_Names))]
        public IHttpActionResult PostAlgoritm_Names(Algoritm_Names algoritm_Names)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AglNames.Add(algoritm_Names);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = algoritm_Names.Id }, algoritm_Names);
        }

        // DELETE: api/AlgoritmNames/5
        [ResponseType(typeof(Algoritm_Names))]
        public IHttpActionResult DeleteAlgoritm_Names(int id)
        {
            Algoritm_Names algoritm_Names = db.AglNames.Find(id);
            if (algoritm_Names == null)
            {
                return NotFound();
            }

            db.AglNames.Remove(algoritm_Names);
            db.SaveChanges();

            return Ok(algoritm_Names);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Algoritm_NamesExists(int id)
        {
            return db.AglNames.Count(e => e.Id == id) > 0;
        }
    }
}