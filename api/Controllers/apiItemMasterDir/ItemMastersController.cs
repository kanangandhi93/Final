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
    public class IMS
    {
        public long ID { get; set; }
        public long CompanyID { get; set; }
        public long ItemGroupID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string ModelNo { get; set; }
        public string Manufacturer { get; set; }
        public string Specification { get; set; }
        public Nullable<short> IsExpired { get; set; }
        public Nullable<long> ItemHSN { get; set; }
        public Nullable<long> PurchaseUnitID { get; set; }
        public Nullable<long> StockUnitID { get; set; }
        public Nullable<long> ProductionUnitID { get; set; }
        public Nullable<long> SalesUnitID { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> MinOrderQty { get; set; }
        public Nullable<decimal> MaxStockLevel { get; set; }
        public Nullable<decimal> MinStockLevel { get; set; }
        public Nullable<decimal> SafetyStockLevel { get; set; }
        public Nullable<decimal> MinLotSize { get; set; }
        public Nullable<decimal> MaxLotSize { get; set; }
        public Nullable<long> DimensionUnitID { get; set; }
        public Nullable<decimal> Length { get; set; }
        public Nullable<decimal> Width { get; set; }
        public Nullable<decimal> Height { get; set; }
        public Nullable<long> WeightUnitID { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public string WeightUnitName { get; set; }
        public string DimensionUnitName { get; set; }
        public string SalesUnitName { get; set; }
        public string PurchaseUnitName { get; set; }
        public string StockUnitName { get; set; }
        public string ProductionUnitName { get; set; }
        public string CompanyName { get; set; }
        public string ItemGroupName { get; set; }

    }
    public class ItemMastersController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/ItemMasters
        public IEnumerable<IMS> GetItemMasters()
        {
            var rr = db.ItemMasters;
            List<IMS> lstrep = new List<IMS>();

            foreach (var item in rr)
            {
                IMS rep = new IMS()
                {
                    BrandName=item.BrandName,
                    Code=item.Code,
                    CompanyID=item.CompanyID,
                    DimensionUnitID=item.DimensionUnitID,
                    Height=item.Height,
                    ID=item.ID,
                    IsExpired=item.IsExpired,
                    ItemGroupID=item.ItemGroupID,
                    Length=item.Length,
                    ItemHSN=item.ItemHSN,
                    Manufacturer=item.Manufacturer,
                    MaxLotSize=item.MaxLotSize,
                    MaxStockLevel=item.MaxStockLevel,
                    MinLotSize=item.MinLotSize,
                    MinOrderQty=item.MinOrderQty,
                    MinStockLevel=item.MinStockLevel,
                    ModelNo=item.ModelNo,
                    Price=item.Price,
                    Name=item.Name,
                    ProductionUnitID=item.ProductionUnitID,
                    PurchaseUnitID=item.PurchaseUnitID,
                    SafetyStockLevel=item.SafetyStockLevel,
                    SalesUnitID=item.SalesUnitID,
                    Specification=item.Specification,
                    StockUnitID=item.StockUnitID,
                    Weight=item.Weight,
                    WeightUnitID=item.WeightUnitID,
                    Width=item.Width
                   
                };
                //if (item.WeightUnitID != null)
                //{
                //    rep.WeightUnitName = db.we.Where(x => x.ID == item.WeightUnitID).SingleOrDefault().Name;

                //}
                lstrep.Add(rep);
            }
            return lstrep;
        }

        // GET: api/ItemMasters/5
        [ResponseType(typeof(ItemMaster))]
        public IHttpActionResult GetItemMaster(long id)
        {
            ItemMaster itemMaster = db.ItemMasters.Find(id);
            if (itemMaster == null)
            {
                return NotFound();
            }

            return Ok(itemMaster);
        }

        // PUT: api/ItemMasters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItemMaster(ItemMaster itemMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (itemMaster.ID != itemMaster.ID)
            {
                return BadRequest();
            }

            db.Entry(itemMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemMasterExists(itemMaster.ID))
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

        // POST: api/ItemMasters
        [ResponseType(typeof(ItemMaster))]
        public IHttpActionResult PostItemMaster(ItemMaster itemMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ItemMasters.Add(itemMaster);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = itemMaster.ID }, itemMaster);
        }

        // DELETE: api/ItemMasters/5
        [ResponseType(typeof(ItemMaster))]
        public IHttpActionResult DeleteItemMaster(long id)
        {
            ItemMaster itemMaster = db.ItemMasters.Find(id);
            if (itemMaster == null)
            {
                return NotFound();
            }

            db.ItemMasters.Remove(itemMaster);
            db.SaveChanges();

            return Ok(itemMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemMasterExists(long id)
        {
            return db.ItemMasters.Count(e => e.ID == id) > 0;
        }
    }
}