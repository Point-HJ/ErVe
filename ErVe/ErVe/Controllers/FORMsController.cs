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
using ErVe.Models;

namespace ErVe.Controllers
{
    public class FORMsController : ApiController
    {
        private ErveEntities db = new ErveEntities();

        // GET: api/FORMs
        public IQueryable<FORM> GetFORM()
        {
            return db.FORM;
        }

        // GET: api/FORMs/5
        [ResponseType(typeof(FORM))]
        public IHttpActionResult GetFORM(int id)
        {
            FORM fORM = db.FORM.Find(id);
            if (fORM == null)
            {
                return NotFound();
            }

            return Ok(fORM);
        }

        // PUT: api/FORMs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFORM(int id, FORM fORM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fORM.FormID)
            {
                return BadRequest();
            }

            db.Entry(fORM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FORMExists(id))
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

        // POST: api/FORMs
        [ResponseType(typeof(FORM))]
        public IHttpActionResult PostFORM(FORM fORM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FORM.Add(fORM);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fORM.FormID }, fORM);
        }

        // DELETE: api/FORMs/5
        [ResponseType(typeof(FORM))]
        public IHttpActionResult DeleteFORM(int id)
        {
            FORM fORM = db.FORM.Find(id);
            if (fORM == null)
            {
                return NotFound();
            }

            db.FORM.Remove(fORM);
            db.SaveChanges();

            return Ok(fORM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FORMExists(int id)
        {
            return db.FORM.Count(e => e.FormID == id) > 0;
        }
    }
}