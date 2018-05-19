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

namespace api.Controllers.apiPartyDir
{
    public class PartyLedgerDetailsController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/PartyLedgerDetails
        public IQueryable<PartyLedgerDetail> GetPartyLedgerDetails()
        {
            return db.PartyLedgerDetails;
        }

        // GET: api/PartyLedgerDetails/5
        [ResponseType(typeof(PartyLedgerDetail))]
        public IHttpActionResult GetPartyLedgerDetail(long id)
        {
            PartyLedgerDetail partyLedgerDetail = db.PartyLedgerDetails.Find(id);
            if (partyLedgerDetail == null)
            {
                return NotFound();
            }

            return Ok(partyLedgerDetail);
        }

        // PUT: api/PartyLedgerDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPartyLedgerDetail(long id, PartyLedgerDetail partyLedgerDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partyLedgerDetail.ID)
            {
                return BadRequest();
            }

            db.Entry(partyLedgerDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartyLedgerDetailExists(id))
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

        // POST: api/PartyLedgerDetails
        [ResponseType(typeof(PartyLedgerDetail))]
        public IHttpActionResult PostPartyLedgerDetail(PartyLedgerDetail partyLedgerDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PartyLedgerDetails.Add(partyLedgerDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = partyLedgerDetail.ID }, partyLedgerDetail);
        }

        // DELETE: api/PartyLedgerDetails/5
        [ResponseType(typeof(PartyLedgerDetail))]
        public IHttpActionResult DeletePartyLedgerDetail(long id)
        {
            PartyLedgerDetail partyLedgerDetail = db.PartyLedgerDetails.Find(id);
            if (partyLedgerDetail == null)
            {
                return NotFound();
            }

            db.PartyLedgerDetails.Remove(partyLedgerDetail);
            db.SaveChanges();

            return Ok(partyLedgerDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PartyLedgerDetailExists(long id)
        {
            return db.PartyLedgerDetails.Count(e => e.ID == id) > 0;
        }
    }
}