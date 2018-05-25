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
    public class clsLookupData
    {
        public long ID { get; set; }
        public Nullable<long> CompanyID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<long> ParentID { get; set; }
        public string ParentName { get; set; }
    }
    public class LookupDatasController : ApiController
    {

        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/LookupDatas
        public IEnumerable<clsLookupData> GetLookupDatas()
        {
            var rr = db.LookupDatas;
            List<clsLookupData> lstrep = new List<clsLookupData>();

            foreach (var item in rr)
            {
                clsLookupData rep = new clsLookupData()
                {
                    Code = item.Code,
                    CompanyID = item.CompanyID,
                    ID = item.ID,
                    Name = item.Name,
                    ParentID = item.ParentID,
                };
                if (item.ParentID != null)
                {
                    rep.ParentName = db.LookupDatas.Where(x => x.ID == item.ParentID).SingleOrDefault().Code;

                }
                lstrep.Add(rep);
            }
            return lstrep;
        }

        // GET: api/LookupDatas/5
        [ResponseType(typeof(LookupData))]
        public IHttpActionResult GetLookupData(long id)
        {
            LookupData lookupData = db.LookupDatas.Find(id);
            if (lookupData == null)
            {
                return NotFound();
            }

            return Ok(lookupData);
        }

        // PUT: api/LookupDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLookupData(LookupData lookupData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (lookupData.ID != lookupData.ID)
            {
                return BadRequest();
            }

            db.Entry(lookupData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LookupDataExists(lookupData.ID))
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

        // POST: api/LookupDatas
        [ResponseType(typeof(LookupData))]
        public IHttpActionResult PostLookupData(LookupData lookupData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LookupDatas.Add(lookupData);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lookupData.ID }, lookupData);
        }

        // DELETE: api/LookupDatas/5
        [ResponseType(typeof(LookupData))]
        public IHttpActionResult DeleteLookupData(long id)
        {
            LookupData lookupData = db.LookupDatas.Find(id);
            if (lookupData == null)
            {
                return NotFound();
            }

            db.LookupDatas.Remove(lookupData);
            db.SaveChanges();

            return Ok(lookupData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LookupDataExists(long id)
        {
            return db.LookupDatas.Count(e => e.ID == id) > 0;
        }
    }
}