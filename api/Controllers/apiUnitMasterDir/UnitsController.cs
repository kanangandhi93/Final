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

namespace api.Controllers.apiUnitMasterDir
{
    
    public class UnitsController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/Units
        public IEnumerable<Unit> GetUnits()
        {
            return db.Units;
        }

        // GET: api/Units/5
        [ResponseType(typeof(Unit))]
        public IHttpActionResult GetUnit(long id)
        {
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return NotFound();
            }

            return Ok(unit);
        }

        // PUT: api/Units/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUnit(long id, Unit unit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unit.ID)
            {
                return BadRequest();
            }

            db.Entry(unit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitExists(id))
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

        // POST: api/Units
        [ResponseType(typeof(Unit))]
        public IHttpActionResult PostUnit(Unit unit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Units.Add(unit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = unit.ID }, unit);
        }

        // DELETE: api/Units/5
        [ResponseType(typeof(Unit))]
        public IHttpActionResult DeleteUnit(long id)
        {
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return NotFound();
            }

            db.Units.Remove(unit);
            db.SaveChanges();

            return Ok(unit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UnitExists(long id)
        {
            return db.Units.Count(e => e.ID == id) > 0;
        }
    }
}