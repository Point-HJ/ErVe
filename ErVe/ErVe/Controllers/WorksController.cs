using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DataAccess2;

namespace ErVe.Controllers
{
    public class WorksController : ApiController
    {
        private ErveEntities db = new ErveEntities();

        // GET: api/Works
        public IQueryable<Work> GetWork()
        {
            return db.Work;
        }

        // GET: api/Works/5
        [ResponseType(typeof(Work))]
        public async Task<IHttpActionResult> GetWork(int id)
        {
            Work work = await db.Work.FindAsync(id);
            if (work == null)
            {
                return NotFound();
            }

            return Ok(work);
        }

        // PUT: api/Works/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWork(int id, Work work)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != work.WorkID)
            {
                return BadRequest();
            }

            db.Entry(work).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkExists(id))
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

        // POST: api/Works
        [ResponseType(typeof(Work))]
        public async Task<IHttpActionResult> PostWork(Work work)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Work.Add(work);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = work.WorkID }, work);
        }

        // DELETE: api/Works/5
        [ResponseType(typeof(Work))]
        public async Task<IHttpActionResult> DeleteWork(int id)
        {
            Work work = await db.Work.FindAsync(id);
            if (work == null)
            {
                return NotFound();
            }

            db.Work.Remove(work);
            await db.SaveChangesAsync();

            return Ok(work);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkExists(int id)
        {
            return db.Work.Count(e => e.WorkID == id) > 0;
        }
    }
}