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
    public class PartyLedgersController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/PartyLedgers
        public IEnumerable<PartyLedger> GetPartyLedgers()
        {
            return db.PartyLedgers;
        }

        // GET: api/PartyLedgers/5
        [ResponseType(typeof(PartyLedger))]
        public IHttpActionResult GetPartyLedger(long id)
        {
            PartyLedger partyLedger = db.PartyLedgers.Find(id);
            if (partyLedger == null)
            {
                return NotFound();
            }

            return Ok(partyLedger);
        }

        // PUT: api/PartyLedgers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPartyLedger(long id, PartyLedger partyLedger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partyLedger.ID)
            {
                return BadRequest();
            }

            db.Entry(partyLedger).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartyLedgerExists(id))
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

        // POST: api/PartyLedgers
        [ResponseType(typeof(PartyLedger))]
        public IHttpActionResult PostPartyLedger(PartyLedger partyLedger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PartyLedgers.Add(partyLedger);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = partyLedger.ID }, partyLedger);
        }

        // DELETE: api/PartyLedgers/5
        [ResponseType(typeof(PartyLedger))]
        public IHttpActionResult DeletePartyLedger(long id)
        {
            PartyLedger partyLedger = db.PartyLedgers.Find(id);
            if (partyLedger == null)
            {
                return NotFound();
            }

            db.PartyLedgers.Remove(partyLedger);
            db.SaveChanges();

            return Ok(partyLedger);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PartyLedgerExists(long id)
        {
            return db.PartyLedgers.Count(e => e.ID == id) > 0;
        }
    }
}