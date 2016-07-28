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
using WebAPIsession5.Models;

namespace WebAPIsession5.Controllers
{
    public class MaterielsController : ApiController
    {
        private WebAPIsession5BDContext db = new WebAPIsession5BDContext();

        // GET: api/Materiels
        public IQueryable<Materiel> GetMateriels()
        {
            return db.Materiels.Include(a=>a.Departement);
        }

        // GET: api/Materiels/5
        [ResponseType(typeof(Materiel))]
        public IHttpActionResult GetMateriel(int id)
        {
            Materiel materiel = db.Materiels.Find(id);
            if (materiel == null)
            {
                return NotFound();
            }

            return Ok(materiel);
        }

        // PUT: api/Materiels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMateriel(int id, Materiel materiel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != materiel.MaterielId)
            {
                return BadRequest();
            }

            db.Entry(materiel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterielExists(id))
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

        // POST: api/Materiels
        [ResponseType(typeof(Materiel))]
        public IHttpActionResult PostMateriel(Materiel materiel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Materiels.Add(materiel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = materiel.MaterielId }, materiel);
        }

        // DELETE: api/Materiels/5
        [ResponseType(typeof(Materiel))]
        public IHttpActionResult DeleteMateriel(int id)
        {
            Materiel materiel = db.Materiels.Find(id);
            if (materiel == null)
            {
                return NotFound();
            }

            db.Materiels.Remove(materiel);
            db.SaveChanges();

            return Ok(materiel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaterielExists(int id)
        {
            return db.Materiels.Count(e => e.MaterielId == id) > 0;
        }
    }
}