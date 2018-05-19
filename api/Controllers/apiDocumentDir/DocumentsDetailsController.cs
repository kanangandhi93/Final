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

namespace api.Controllers.apiDocumentDir
{
    public class DocumentsDetailsController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/DocumentsDetails
        public IEnumerable<DocumentsDetail> GetDocumentsDetails()
        {
            return db.DocumentsDetails;
        }

        // GET: api/DocumentsDetails/5
        [ResponseType(typeof(DocumentsDetail))]
        public IHttpActionResult GetDocumentsDetail(long id)
        {
            DocumentsDetail documentsDetail = db.DocumentsDetails.Find(id);
            if (documentsDetail == null)
            {
                return NotFound();
            }

            return Ok(documentsDetail);
        }

        // PUT: api/DocumentsDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDocumentsDetail(long id, DocumentsDetail documentsDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documentsDetail.ID)
            {
                return BadRequest();
            }

            db.Entry(documentsDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentsDetailExists(id))
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

        // POST: api/DocumentsDetails
        [ResponseType(typeof(DocumentsDetail))]
        public IHttpActionResult PostDocumentsDetail(DocumentsDetail documentsDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DocumentsDetails.Add(documentsDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DocumentsDetailExists(documentsDetail.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = documentsDetail.ID }, documentsDetail);
        }

        // DELETE: api/DocumentsDetails/5
        [ResponseType(typeof(DocumentsDetail))]
        public IHttpActionResult DeleteDocumentsDetail(long id)
        {
            DocumentsDetail documentsDetail = db.DocumentsDetails.Find(id);
            if (documentsDetail == null)
            {
                return NotFound();
            }

            db.DocumentsDetails.Remove(documentsDetail);
            db.SaveChanges();

            return Ok(documentsDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DocumentsDetailExists(long id)
        {
            return db.DocumentsDetails.Count(e => e.ID == id) > 0;
        }
    }
}