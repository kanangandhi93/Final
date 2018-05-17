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
    public class clsIDs
    {
        public long ID { get; set; }
        public long ItemID { get; set; }
        public Nullable<long> FinancialYearID { get; set; }
        public Nullable<long> DocumentID { get; set; }
        public Nullable<long> TransactionID { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public Nullable<long> LocationID { get; set; }
        public Nullable<decimal> OpeningStock { get; set; }
        public Nullable<decimal> TransactionQty { get; set; }
        public Nullable<decimal> ClosingStock { get; set; }
        public string FinancialCode { get; set; }
        public string DocumentCode { get; set; }
        public string ItemCode { get; set; }
    }
    public class ItemStockDetailsController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/ItemStockDetails
        public IEnumerable<clsIDs> GetItemStockDetails()
        {
            var rr = db.ItemStockDetails;

            List<clsIDs> lstrep = new List<clsIDs>();

            foreach (var item in rr)
            {
                clsIDs rep = new clsIDs()
                {
                    ClosingStock = item.ClosingStock,
                    DocumentID = item.DocumentID,
                    FinancialYearID = item.FinancialYearID,
                    ID = item.ID,
                    ItemID = item.ItemID,
                    LocationID = item.LocationID,
                    OpeningStock = item.OpeningStock,
                    TransactionDate = item.TransactionDate,
                    TransactionID = item.TransactionID,
                    TransactionQty = item.TransactionQty
                };
                if (item.FinancialYearID != null)
                {
                    rep.FinancialCode = db.FinancialYears.Where(x => x.ID == item.FinancialYearID).SingleOrDefault().Code;
                }
                if (item.DocumentID != null)
                {
                    rep.DocumentCode = db.DocumentsLists.Where(x => x.ID == item.DocumentID).SingleOrDefault().DocCode;
                }
                if (item.ItemID != null)
                {
                    rep.ItemCode = db.ItemMasters.Where(x => x.ID == item.ItemID).SingleOrDefault().Code;
                }
                lstrep.Add(rep);
            }
            return lstrep;
        }

        // GET: api/ItemStockDetails/5
        [ResponseType(typeof(ItemStockDetail))]
        public IHttpActionResult GetItemStockDetail(long id)
        {
            ItemStockDetail itemStockDetail = db.ItemStockDetails.Find(id);
            if (itemStockDetail == null)
            {
                return NotFound();
            }

            return Ok(itemStockDetail);
        }

        // PUT: api/ItemStockDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItemStockDetail(long id, ItemStockDetail itemStockDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemStockDetail.ID)
            {
                return BadRequest();
            }

            db.Entry(itemStockDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemStockDetailExists(id))
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

        // POST: api/ItemStockDetails
        [ResponseType(typeof(ItemStockDetail))]
        public IHttpActionResult PostItemStockDetail(ItemStockDetail itemStockDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ItemStockDetails.Add(itemStockDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = itemStockDetail.ID }, itemStockDetail);
        }

        // DELETE: api/ItemStockDetails/5
        [ResponseType(typeof(ItemStockDetail))]
        public IHttpActionResult DeleteItemStockDetail(long id)
        {
            ItemStockDetail itemStockDetail = db.ItemStockDetails.Find(id);
            if (itemStockDetail == null)
            {
                return NotFound();
            }

            db.ItemStockDetails.Remove(itemStockDetail);
            db.SaveChanges();

            return Ok(itemStockDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemStockDetailExists(long id)
        {
            return db.ItemStockDetails.Count(e => e.ID == id) > 0;
        }
    }
}