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
using api.Models;

namespace api.Controllers.apiCompanyDir
{
    public class CompanyLocationsController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/CompanyLocations
        public IEnumerable<CompanyLocation> GetCompanyLocations()
        {
            return db.CompanyLocations;
        }

        // GET: api/CompanyLocations/5
        [ResponseType(typeof(CompanyLocation))]
        public IHttpActionResult GetCompanyLocation(long id)
        {
            CompanyLocation companyLocation = db.CompanyLocations.Find(id);
            if (companyLocation == null)
            {
                return NotFound();
            }

            return Ok(companyLocation);
        }

        // PUT: api/CompanyLocations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompanyLocation(long id, CompanyLocation companyLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyLocation.ID)
            {
                return BadRequest();
            }

            db.Entry(companyLocation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyLocationExists(id))
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

        // POST: api/CompanyLocations
        [ResponseType(typeof(CompanyLocation))]
        public IHttpActionResult PostCompanyLocation(CompanyLocation companyLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CompanyLocations.Add(companyLocation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = companyLocation.ID }, companyLocation);
        }

        // DELETE: api/CompanyLocations/5
        [ResponseType(typeof(CompanyLocation))]
        public IHttpActionResult DeleteCompanyLocation(long id)
        {
            CompanyLocation companyLocation = db.CompanyLocations.Find(id);
            if (companyLocation == null)
            {
                return NotFound();
            }

            db.CompanyLocations.Remove(companyLocation);
            db.SaveChanges();

            return Ok(companyLocation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyLocationExists(long id)
        {
            return db.CompanyLocations.Count(e => e.ID == id) > 0;
        }
    }
}