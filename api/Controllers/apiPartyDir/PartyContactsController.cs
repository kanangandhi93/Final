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
    public class PartyContactsController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/PartyContacts
        public IEnumerable<PartyContact> GetPartyContacts()
        {
            return db.PartyContacts;
        }

        // GET: api/PartyContacts/5
        [ResponseType(typeof(PartyContact))]
        public IHttpActionResult GetPartyContact(long id)
        {
            PartyContact partyContact = db.PartyContacts.Find(id);
            if (partyContact == null)
            {
                return NotFound();
            }

            return Ok(partyContact);
        }

        // PUT: api/PartyContacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPartyContact(long id, PartyContact partyContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partyContact.ID)
            {
                return BadRequest();
            }

            db.Entry(partyContact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartyContactExists(id))
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

        // POST: api/PartyContacts
        [ResponseType(typeof(PartyContact))]
        public IHttpActionResult PostPartyContact(PartyContact partyContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PartyContacts.Add(partyContact);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = partyContact.ID }, partyContact);
        }

        // DELETE: api/PartyContacts/5
        [ResponseType(typeof(PartyContact))]
        public IHttpActionResult DeletePartyContact(long id)
        {
            PartyContact partyContact = db.PartyContacts.Find(id);
            if (partyContact == null)
            {
                return NotFound();
            }

            db.PartyContacts.Remove(partyContact);
            db.SaveChanges();

            return Ok(partyContact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PartyContactExists(long id)
        {
            return db.PartyContacts.Count(e => e.ID == id) > 0;
        }
    }
}