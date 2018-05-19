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
    public class DocumentsListsController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/DocumentsLists
        public IEnumerable<DocumentsList> GetDocumentsLists()
        {
            return db.DocumentsLists;
        }

        // GET: api/DocumentsLists/5
        [ResponseType(typeof(DocumentsList))]
        public IHttpActionResult GetDocumentsList(long id)
        {
            DocumentsList documentsList = db.DocumentsLists.Find(id);
            if (documentsList == null)
            {
                return NotFound();
            }

            return Ok(documentsList);
        }

        // PUT: api/DocumentsLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDocumentsList(long id, DocumentsList documentsList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documentsList.ID)
            {
                return BadRequest();
            }

            db.Entry(documentsList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentsListExists(id))
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

        // POST: api/DocumentsLists
        [ResponseType(typeof(DocumentsList))]
        public IHttpActionResult PostDocumentsList(DocumentsList documentsList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DocumentsLists.Add(documentsList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = documentsList.ID }, documentsList);
        }

        // DELETE: api/DocumentsLists/5
        [ResponseType(typeof(DocumentsList))]
        public IHttpActionResult DeleteDocumentsList(long id)
        {
            DocumentsList documentsList = db.DocumentsLists.Find(id);
            if (documentsList == null)
            {
                return NotFound();
            }

            db.DocumentsLists.Remove(documentsList);
            db.SaveChanges();

            return Ok(documentsList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DocumentsListExists(long id)
        {
            return db.DocumentsLists.Count(e => e.ID == id) > 0;
        }
    }
}