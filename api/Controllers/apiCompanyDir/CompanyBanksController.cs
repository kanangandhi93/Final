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
    public class CompanyBanksController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/CompanyBanks
        public IEnumerable<CompanyBank> GetCompanyBanks()
        {
            return db.CompanyBanks;
        }

        // GET: api/CompanyBanks/5
        [ResponseType(typeof(CompanyBank))]
        public IHttpActionResult GetCompanyBank(long id)
        {
            CompanyBank companyBank = db.CompanyBanks.Find(id);
            if (companyBank == null)
            {
                return NotFound();
            }

            return Ok(companyBank);
        }

        // PUT: api/CompanyBanks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompanyBank(long id, CompanyBank companyBank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyBank.ID)
            {
                return BadRequest();
            }

            db.Entry(companyBank).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyBankExists(id))
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

        // POST: api/CompanyBanks
        [ResponseType(typeof(CompanyBank))]
        public IHttpActionResult PostCompanyBank(CompanyBank companyBank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CompanyBanks.Add(companyBank);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CompanyBankExists(companyBank.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = companyBank.ID }, companyBank);
        }

        // DELETE: api/CompanyBanks/5
        [ResponseType(typeof(CompanyBank))]
        public IHttpActionResult DeleteCompanyBank(long id)
        {
            CompanyBank companyBank = db.CompanyBanks.Find(id);
            if (companyBank == null)
            {
                return NotFound();
            }

            db.CompanyBanks.Remove(companyBank);
            db.SaveChanges();

            return Ok(companyBank);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyBankExists(long id)
        {
            return db.CompanyBanks.Count(e => e.ID == id) > 0;
        }
    }
}