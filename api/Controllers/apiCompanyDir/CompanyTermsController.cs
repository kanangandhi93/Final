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
    public class CompanyTermsController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/CompanyTerms
        public IEnumerable<CompanyTerm> GetCompanyTerms()
        {
            return db.CompanyTerms;
        }

        // GET: api/CompanyTerms/5
        [ResponseType(typeof(CompanyTerm))]
        public IHttpActionResult GetCompanyTerm(long id)
        {
            CompanyTerm companyTerm = db.CompanyTerms.Find(id);
            if (companyTerm == null)
            {
                return NotFound();
            }

            return Ok(companyTerm);
        }

        // PUT: api/CompanyTerms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompanyTerm(long id, CompanyTerm companyTerm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyTerm.ID)
            {
                return BadRequest();
            }

            db.Entry(companyTerm).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyTermExists(id))
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

        // POST: api/CompanyTerms
        [ResponseType(typeof(CompanyTerm))]
        public IHttpActionResult PostCompanyTerm(CompanyTerm companyTerm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CompanyTerms.Add(companyTerm);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = companyTerm.ID }, companyTerm);
        }

        // DELETE: api/CompanyTerms/5
        [ResponseType(typeof(CompanyTerm))]
        public IHttpActionResult DeleteCompanyTerm(long id)
        {
            CompanyTerm companyTerm = db.CompanyTerms.Find(id);
            if (companyTerm == null)
            {
                return NotFound();
            }

            db.CompanyTerms.Remove(companyTerm);
            db.SaveChanges();

            return Ok(companyTerm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyTermExists(long id)
        {
            return db.CompanyTerms.Count(e => e.ID == id) > 0;
        }
    }
}