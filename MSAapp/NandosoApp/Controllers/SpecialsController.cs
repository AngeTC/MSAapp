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
using NandosoApp.Models;

namespace NandosoApp.Controllers
{
    public class SpecialsController : ApiController
    {
        private NandosoAppUpdatedContext db = new NandosoAppUpdatedContext();

        // GET: api/Specials
        public IQueryable<Special> GetSpecials()
        {
            return db.Specials;
        }

        // GET: api/Specials/5
        [ResponseType(typeof(Special))]
        public IHttpActionResult GetSpecial(int id)
        {
            Special special = db.Specials.Find(id);
            if (special == null)
            {
                return NotFound();
            }

            return Ok(special);
        }

        // PUT: api/Specials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSpecial(int id, Special special)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != special.ID)
            {
                return BadRequest();
            }

            db.Entry(special).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialExists(id))
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

        // POST: api/Specials
        [ResponseType(typeof(Special))]
        public IHttpActionResult PostSpecial(Special special)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Specials.Add(special);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = special.ID }, special);
        }

        // DELETE: api/Specials/5
        [ResponseType(typeof(Special))]
        public IHttpActionResult DeleteSpecial(int id)
        {
            Special special = db.Specials.Find(id);
            if (special == null)
            {
                return NotFound();
            }

            db.Specials.Remove(special);
            db.SaveChanges();

            return Ok(special);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpecialExists(int id)
        {
            return db.Specials.Count(e => e.ID == id) > 0;
        }
    }
}