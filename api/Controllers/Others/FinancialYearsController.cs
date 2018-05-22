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

namespace api.Controllers.Others
{
    public class FinancialYearsController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/FinancialYears
        public IEnumerable<FinancialYear> GetFinancialYears()
        {
            return db.FinancialYears.Where(i => i.IsCurrentYear == true);
        }

        // GET: api/FinancialYears/5
        [ResponseType(typeof(FinancialYear))]
        public IHttpActionResult GetFinancialYear(long id)
        {
            FinancialYear financialYear = db.FinancialYears.Find(id);
            if (financialYear == null)
            {
                return NotFound();
            }

            return Ok(financialYear);
        }

        // PUT: api/FinancialYears/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFinancialYear(FinancialYear financialYear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (financialYear.ID != financialYear.ID)
            {
                return BadRequest();
            }

            db.Entry(financialYear).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancialYearExists(financialYear.ID))
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

        // POST: api/FinancialYears
        [ResponseType(typeof(FinancialYear))]
        public IHttpActionResult PostFinancialYear(FinancialYear financialYear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FinancialYears.Add(financialYear);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = financialYear.ID }, financialYear);
        }

        // DELETE: api/FinancialYears/5
        [ResponseType(typeof(FinancialYear))]
        public IHttpActionResult DeleteFinancialYear(long id)
        {
            FinancialYear financialYear = db.FinancialYears.Find(id);
            if (financialYear == null)
            {
                return NotFound();
            }

            db.FinancialYears.Remove(financialYear);
            db.SaveChanges();

            return Ok(financialYear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FinancialYearExists(long id)
        {
            return db.FinancialYears.Count(e => e.ID == id) > 0;
        }
    }
}