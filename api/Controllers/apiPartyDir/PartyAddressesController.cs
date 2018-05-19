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
    public class PartyAddressesController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/PartyAddresses
        public IEnumerable<PartyAddress> GetPartyAddresses()
        {
            return db.PartyAddresses;
        }

        // GET: api/PartyAddresses/5
        [ResponseType(typeof(PartyAddress))]
        public IHttpActionResult GetPartyAddress(long id)
        {
            PartyAddress partyAddress = db.PartyAddresses.Find(id);
            if (partyAddress == null)
            {
                return NotFound();
            }

            return Ok(partyAddress);
        }

        // PUT: api/PartyAddresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPartyAddress(long id, PartyAddress partyAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partyAddress.ID)
            {
                return BadRequest();
            }

            db.Entry(partyAddress).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartyAddressExists(id))
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

        // POST: api/PartyAddresses
        [ResponseType(typeof(PartyAddress))]
        public IHttpActionResult PostPartyAddress(PartyAddress partyAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PartyAddresses.Add(partyAddress);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PartyAddressExists(partyAddress.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = partyAddress.ID }, partyAddress);
        }

        // DELETE: api/PartyAddresses/5
        [ResponseType(typeof(PartyAddress))]
        public IHttpActionResult DeletePartyAddress(long id)
        {
            PartyAddress partyAddress = db.PartyAddresses.Find(id);
            if (partyAddress == null)
            {
                return NotFound();
            }

            db.PartyAddresses.Remove(partyAddress);
            db.SaveChanges();

            return Ok(partyAddress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PartyAddressExists(long id)
        {
            return db.PartyAddresses.Count(e => e.ID == id) > 0;
        }
    }
}