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
    public class clsState
    {
        public long ID { get; set; }
        public long CountryID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }

    }
    public class StatesController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/States
        public IEnumerable<clsState> GetStates()
        {
            var rr = db.States;

            List<clsState> lstrep = new List<clsState>();

            foreach (var item in rr)
            {
                clsState rep = new clsState()
                {
                   Code=item.Code,
                   ID=item.ID,
                   CountryID=item.CountryID,
                   Name=item.Name
                };
                if (item.CountryID != null)
                {
                    rep.CountryCode = db.Countries.Where(x => x.ID == item.CountryID).SingleOrDefault().Code;

                }
                lstrep.Add(rep);
            }
            return lstrep;
        }

        // GET: api/States/5
        [ResponseType(typeof(State))]
        public IHttpActionResult GetState(long id)
        {
            State state = db.States.Find(id);
            if (state == null)
            {
                return NotFound();
            }

            return Ok(state);
        }

        // PUT: api/States/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutState(long id, State state)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != state.ID)
            {
                return BadRequest();
            }

            db.Entry(state).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateExists(id))
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

        // POST: api/States
        [ResponseType(typeof(State))]
        public IHttpActionResult PostState(State state)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.States.Add(state);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = state.ID }, state);
        }

        // DELETE: api/States/5
        [ResponseType(typeof(State))]
        public IHttpActionResult DeleteState(long id)
        {
            State state = db.States.Find(id);
            if (state == null)
            {
                return NotFound();
            }

            db.States.Remove(state);
            db.SaveChanges();

            return Ok(state);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StateExists(long id)
        {
            return db.States.Count(e => e.ID == id) > 0;
        }
    }
}