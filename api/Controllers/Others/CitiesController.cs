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
    public class clsCity
    {
        public long ID { get; set; }
        public long StateID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string StateName { get; set; }
    }
    public class CitiesController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/Cities
        public IEnumerable<clsCity> GetCities()
        {
            var rr= db.Cities;
            List<clsCity> lstrep = new List<clsCity>();

            foreach (var item in rr)
            {
                clsCity rep = new clsCity()
                {
                    Code = item.Code,
                    ID = item.ID,
                    StateID = item.StateID,
                    Name = item.Name
                };
                if (item.StateID != null)
                {
                    rep.StateName = db.States.Where(x => x.ID == item.StateID).SingleOrDefault().Code;

                }
                lstrep.Add(rep);
            }
            return lstrep;
        }

        // GET: api/Cities/5
        [ResponseType(typeof(City))]
        public IHttpActionResult GetCity(long id)
        {
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        // PUT: api/Cities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCity(long id, City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != city.ID)
            {
                return BadRequest();
            }

            db.Entry(city).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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

        // POST: api/Cities
        [ResponseType(typeof(City))]
        public IHttpActionResult PostCity(City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cities.Add(city);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = city.ID }, city);
        }

        // DELETE: api/Cities/5
        [ResponseType(typeof(City))]
        public IHttpActionResult DeleteCity(long id)
        {
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }

            db.Cities.Remove(city);
            db.SaveChanges();

            return Ok(city);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CityExists(long id)
        {
            return db.Cities.Count(e => e.ID == id) > 0;
        }
    }
}