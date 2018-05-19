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
    public class PaymentReceiptDetailsController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/PaymentReceiptDetails
        public IEnumerable<PaymentReceiptDetail> GetPaymentReceiptDetails()
        {
            return db.PaymentReceiptDetails;
        }

        // GET: api/PaymentReceiptDetails/5
        [ResponseType(typeof(PaymentReceiptDetail))]
        public IHttpActionResult GetPaymentReceiptDetail(long id)
        {
            PaymentReceiptDetail paymentReceiptDetail = db.PaymentReceiptDetails.Find(id);
            if (paymentReceiptDetail == null)
            {
                return NotFound();
            }

            return Ok(paymentReceiptDetail);
        }

        // PUT: api/PaymentReceiptDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPaymentReceiptDetail(long id, PaymentReceiptDetail paymentReceiptDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentReceiptDetail.ID)
            {
                return BadRequest();
            }

            db.Entry(paymentReceiptDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentReceiptDetailExists(id))
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

        // POST: api/PaymentReceiptDetails
        [ResponseType(typeof(PaymentReceiptDetail))]
        public IHttpActionResult PostPaymentReceiptDetail(PaymentReceiptDetail paymentReceiptDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PaymentReceiptDetails.Add(paymentReceiptDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = paymentReceiptDetail.ID }, paymentReceiptDetail);
        }

        // DELETE: api/PaymentReceiptDetails/5
        [ResponseType(typeof(PaymentReceiptDetail))]
        public IHttpActionResult DeletePaymentReceiptDetail(long id)
        {
            PaymentReceiptDetail paymentReceiptDetail = db.PaymentReceiptDetails.Find(id);
            if (paymentReceiptDetail == null)
            {
                return NotFound();
            }

            db.PaymentReceiptDetails.Remove(paymentReceiptDetail);
            db.SaveChanges();

            return Ok(paymentReceiptDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentReceiptDetailExists(long id)
        {
            return db.PaymentReceiptDetails.Count(e => e.ID == id) > 0;
        }
    }
}