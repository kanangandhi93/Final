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
    public class ItemStocksController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/ItemStocks
        public IQueryable<ItemStock> GetItemStocks()
        {
            return db.ItemStocks;
        }

        // GET: api/ItemStocks/5
        [ResponseType(typeof(ItemStock))]
        public IHttpActionResult GetItemStock(long id)
        {
            ItemStock itemStock = db.ItemStocks.Find(id);
            if (itemStock == null)
            {
                return NotFound();
            }

            return Ok(itemStock);
        }

        // PUT: api/ItemStocks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItemStock(long id, ItemStock itemStock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemStock.ID)
            {
                return BadRequest();
            }

            db.Entry(itemStock).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemStockExists(id))
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

        // POST: api/ItemStocks
        [ResponseType(typeof(ItemStock))]
        public IHttpActionResult PostItemStock(ItemStock itemStock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ItemStocks.Add(itemStock);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = itemStock.ID }, itemStock);
        }

        // DELETE: api/ItemStocks/5
        [ResponseType(typeof(ItemStock))]
        public IHttpActionResult DeleteItemStock(long id)
        {
            ItemStock itemStock = db.ItemStocks.Find(id);
            if (itemStock == null)
            {
                return NotFound();
            }

            db.ItemStocks.Remove(itemStock);
            db.SaveChanges();

            return Ok(itemStock);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemStockExists(long id)
        {
            return db.ItemStocks.Count(e => e.ID == id) > 0;
        }
    }
}