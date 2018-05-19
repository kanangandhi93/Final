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

namespace api.Controllers.apiPaymentDir
{
    public class PaymentReceiptMastersController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/PaymentReceiptMasters
        public IEnumerable<PaymentReceiptMaster> GetPaymentReceiptMasters()
        {
            return db.PaymentReceiptMasters;
        }

        // GET: api/PaymentReceiptMasters/5
        [ResponseType(typeof(PaymentReceiptMaster))]
        public IHttpActionResult GetPaymentReceiptMaster(long id)
        {
            PaymentReceiptMaster paymentReceiptMaster = db.PaymentReceiptMasters.Find(id);
            if (paymentReceiptMaster == null)
            {
                return NotFound();
            }

            return Ok(paymentReceiptMaster);
        }

        // PUT: api/PaymentReceiptMasters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaymentReceiptMaster(long id, PaymentReceiptMaster paymentReceiptMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentReceiptMaster.ID)
            {
                return BadRequest();
            }

            db.Entry(paymentReceiptMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentReceiptMasterExists(id))
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

        // POST: api/PaymentReceiptMasters
        [ResponseType(typeof(PaymentReceiptMaster))]
        public IHttpActionResult PostPaymentReceiptMaster(PaymentReceiptMaster paymentReceiptMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PaymentReceiptMasters.Add(paymentReceiptMaster);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PaymentReceiptMasterExists(paymentReceiptMaster.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = paymentReceiptMaster.ID }, paymentReceiptMaster);
        }

        // DELETE: api/PaymentReceiptMasters/5
        [ResponseType(typeof(PaymentReceiptMaster))]
        public IHttpActionResult DeletePaymentReceiptMaster(long id)
        {
            PaymentReceiptMaster paymentReceiptMaster = db.PaymentReceiptMasters.Find(id);
            if (paymentReceiptMaster == null)
            {
                return NotFound();
            }

            db.PaymentReceiptMasters.Remove(paymentReceiptMaster);
            db.SaveChanges();

            return Ok(paymentReceiptMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentReceiptMasterExists(long id)
        {
            return db.PaymentReceiptMasters.Count(e => e.ID == id) > 0;
        }
    }
}