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
using AutoMapper;
using DataAccess2;
using Microsoft.AspNetCore.JsonPatch;

namespace ErVe.Controllers
{
    
    public class FORMsController : ApiController
    {
        private ErveEntities db = new ErveEntities();

        // GET: /api/FORMs
        //[HttpGet, HttpPost]
        //[Route("api/FORMs")]
        public IQueryable<FORM> GetFORMs()
        {
             return db.FORM;
        }

        // GET: api/FORMs/5
        [ResponseType(typeof(FORM))]
        public async Task<IHttpActionResult> GetFORM(int id)
        {
            FORM fORM = await db.FORM.FindAsync(id);
            if (fORM == null)
            {
                return NotFound();
            }

            return Ok(fORM);
        }

        // PUT: api/FORMs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFORM(int id, FORM fORM)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostForm(FORM form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FORM.Add(form);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = form.FormID }, form);
        }
        



        // DELETE: api/FORMs/5
        [ResponseType(typeof(FORM))]
        public async Task<IHttpActionResult> DeleteFORM(int id)
        {
            FORM fORM = await db.FORM.FindAsync(id);
            if (fORM == null)
            {
                return NotFound();
            }

            db.FORM.Remove(fORM);
            await db.SaveChangesAsync();

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