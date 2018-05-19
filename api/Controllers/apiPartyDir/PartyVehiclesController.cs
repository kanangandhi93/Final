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
    public class PartyVehiclesController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/PartyVehicles
        public IEnumerable<PartyVehicle> GetPartyVehicles()
        {
            return db.PartyVehicles;
        }

        // GET: api/PartyVehicles/5
        [ResponseType(typeof(PartyVehicle))]
        public IHttpActionResult GetPartyVehicle(long id)
        {
            PartyVehicle partyVehicle = db.PartyVehicles.Find(id);
            if (partyVehicle == null)
            {
                return NotFound();
            }

            return Ok(partyVehicle);
        }

        // PUT: api/PartyVehicles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPartyVehicle(long id, PartyVehicle partyVehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partyVehicle.ID)
            {
                return BadRequest();
            }

            db.Entry(partyVehicle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartyVehicleExists(id))
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

        // POST: api/PartyVehicles
        [ResponseType(typeof(PartyVehicle))]
        public IHttpActionResult PostPartyVehicle(PartyVehicle partyVehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PartyVehicles.Add(partyVehicle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = partyVehicle.ID }, partyVehicle);
        }

        // DELETE: api/PartyVehicles/5
        [ResponseType(typeof(PartyVehicle))]
        public IHttpActionResult DeletePartyVehicle(long id)
        {
            PartyVehicle partyVehicle = db.PartyVehicles.Find(id);
            if (partyVehicle == null)
            {
                return NotFound();
            }

            db.PartyVehicles.Remove(partyVehicle);
            db.SaveChanges();

            return Ok(partyVehicle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PartyVehicleExists(long id)
        {
            return db.PartyVehicles.Count(e => e.ID == id) > 0;
        }
    }
}