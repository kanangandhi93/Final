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
    public class clsUnitConversion
    {
        public long ID { get; set; }
        public long CompanyID { get; set; }
        public string Name { get; set; }
        public Nullable<long> FromUnitID { get; set; }
        public Nullable<int> FromValue { get; set; }
        public Nullable<long> ToUnitID { get; set; }
        public Nullable<int> ToValue { get; set; }
        public string Ratio { get; set; }
        public string FromUnitCode { get; set; }
        public string ToUnitCode { get; set; }
    }
    public class UnitConversionsController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/UnitConversions
        public IEnumerable<clsUnitConversion> GetUnitConversions()
        {
            var rr = db.UnitConversions;
            List<clsUnitConversion> lstrep = new List<clsUnitConversion>();

            foreach (var item in rr)
            {
                clsUnitConversion rep = new clsUnitConversion()
                {
                  CompanyID=item.CompanyID,
                  FromUnitID=item.FromUnitID,
                  FromValue=item.FromValue,
                  ID=item.ID,
                  Name=item.Name,
                  Ratio=item.Ratio,
                  ToUnitID=item.ToUnitID,
                  ToValue=item.ToValue
                };
                if (item.FromUnitID != null)
                {
                    rep.FromUnitCode = db.Units.Where(x => x.ID == item.FromUnitID).SingleOrDefault().Code;
                }
                if (item.ToUnitID != null)
                {
                    rep.ToUnitCode = db.Units.Where(x => x.ID == item.ToUnitID).SingleOrDefault().Code;
                }
                lstrep.Add(rep);
            }
            return lstrep;
        }

        // GET: api/UnitConversions/5
        [ResponseType(typeof(UnitConversion))]
        public IHttpActionResult GetUnitConversion(long id)
        {
            UnitConversion unitConversion = db.UnitConversions.Find(id);
            if (unitConversion == null)
            {
                return NotFound();
            }

            return Ok(unitConversion);
        }

        // PUT: api/UnitConversions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUnitConversion(long id, UnitConversion unitConversion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unitConversion.ID)
            {
                return BadRequest();
            }

            db.Entry(unitConversion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitConversionExists(id))
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

        // POST: api/UnitConversions
        [ResponseType(typeof(UnitConversion))]
        public IHttpActionResult PostUnitConversion(UnitConversion unitConversion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UnitConversions.Add(unitConversion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = unitConversion.ID }, unitConversion);
        }

        // DELETE: api/UnitConversions/5
        [ResponseType(typeof(UnitConversion))]
        public IHttpActionResult DeleteUnitConversion(long id)
        {
            UnitConversion unitConversion = db.UnitConversions.Find(id);
            if (unitConversion == null)
            {
                return NotFound();
            }

            db.UnitConversions.Remove(unitConversion);
            db.SaveChanges();

            return Ok(unitConversion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UnitConversionExists(long id)
        {
            return db.UnitConversions.Count(e => e.ID == id) > 0;
        }
    }
}