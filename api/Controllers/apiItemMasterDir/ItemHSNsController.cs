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

namespace api.Controllers.apiItemMasterDir
{
    public class ItemHSNRep
    {
        public long ID { get; set; }
        public string HSNCode { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> CGST { get; set; }
        public Nullable<decimal> SGST { get; set; }
        public Nullable<decimal> IGST { get; set; }
        public Nullable<System.DateTime> EffectiveFrom { get; set; }
        public Nullable<decimal> AmendmentNo { get; set; }
        public Nullable<long> ParentID { get; set; }
        public string ParentName { get; set; }

    }
    public class ItemHSNsController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/ItemHSNs
        public IEnumerable<ItemHSNRep> GetItemHSNs()
        {
            var rr = db.ItemHSNs;
            List<ItemHSNRep> lstrep = new List<ItemHSNRep>();

            foreach (var item in rr)
            {
                ItemHSNRep rep = new ItemHSNRep()
                {
                    AmendmentNo = item.AmendmentNo,
                    CGST = item.CGST,
                    EffectiveFrom = item.EffectiveFrom,
                    HSNCode = item.HSNCode,
                    ID = item.ID,
                    IGST = item.IGST,
                    Name = item.Name,
                    ParentID = item.ParentID,
                    SGST = item.SGST
                };
                if (item.ParentID != null)
                {
                    rep.ParentName = db.ItemHSNs.Where(x => x.ID == item.ParentID).SingleOrDefault().Name;

                }
                lstrep.Add(rep);
            }
            return lstrep;
        }

        // GET: api/ItemHSNs/5
        [ResponseType(typeof(ItemHSN))]
        public IHttpActionResult GetItemHSN(long id)
        {
            ItemHSN itemHSN = db.ItemHSNs.Find(id);
            if (itemHSN == null)
            {
                return NotFound();
            }

            return Ok(itemHSN);
        }

        // PUT: api/ItemHSNs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItemHSN(ItemHSN itemHSN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (itemHSN.ID != itemHSN.ID)
            {
                return BadRequest();
            }

            db.Entry(itemHSN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemHSNExists(itemHSN.ID))
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

        // POST: api/ItemHSNs
        [ResponseType(typeof(ItemHSN))]
        public IHttpActionResult PostItemHSN(ItemHSN itemHSN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ItemHSNs.Add(itemHSN);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = itemHSN.ID }, itemHSN);
        }

        // DELETE: api/ItemHSNs/5
        [ResponseType(typeof(ItemHSN))]
        public IHttpActionResult DeleteItemHSN(long id)
        {
            ItemHSN itemHSN = db.ItemHSNs.Find(id);
            if (itemHSN == null)
            {
                return NotFound();
            }

            db.ItemHSNs.Remove(itemHSN);
            db.SaveChanges();

            return Ok(itemHSN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemHSNExists(long id)
        {
            return db.ItemHSNs.Count(e => e.ID == id) > 0;
        }
    }
}