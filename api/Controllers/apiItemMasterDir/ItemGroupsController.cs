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
    public class ItemGroupRep
    {
        public long ID { get; set; }
        public long CompanyID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<long> ParentGroupID { get; set; }
        public string ParentName { get; set; }
    }
    public class ItemGroupsController : ApiController
    {
        private InventoryControlEntities db = new InventoryControlEntities();

        // GET: api/ItemGroups
        public IEnumerable<ItemGroupRep> GetItemGroups()
        {
            var rr = db.ItemGroups;

            List<ItemGroupRep> lstrep = new List<ItemGroupRep>();

            foreach (var item in rr)
            {
                ItemGroupRep rep = new ItemGroupRep()
                {
                    Code = item.Code,
                    CompanyID = item.CompanyID,
                    ID = item.ID,
                    Name = item.Name,
                    ParentGroupID = item.ParentGroupID,
                };
                if (item.ParentGroupID!=null)
                {
                    rep.ParentName = db.ItemGroups.Where(x => x.ID == item.ParentGroupID).SingleOrDefault().Name;

                }
                lstrep.Add(rep);
            }
            return lstrep;
        }

        // GET: api/ItemGroups/5
        [ResponseType(typeof(ItemGroup))]
        public IHttpActionResult GetItemGroup(long id)
        {
            ItemGroup itemGroup = db.ItemGroups.Find(id);
            if (itemGroup == null)
            {
                return NotFound();
            }

            return Ok(itemGroup);
        }

        // PUT: api/ItemGroups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItemGroup(ItemGroup itemGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (itemGroup.ID != itemGroup.ID)
            //{
            //    return BadRequest();
            //}

            db.Entry(itemGroup).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemGroupExists(itemGroup.ID))
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

        // POST: api/ItemGroups
        [ResponseType(typeof(ItemGroup))]
        public IHttpActionResult PostItemGroup(ItemGroup itemGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ItemGroups.Add(itemGroup);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = itemGroup.ID }, itemGroup);
        }

        // DELETE: api/ItemGroups/5
        [ResponseType(typeof(ItemGroup))]
        public IHttpActionResult DeleteItemGroup(long id)
        {
            ItemGroup itemGroup = db.ItemGroups.Find(id);
            if (itemGroup == null)
            {
                return NotFound();
            }

            db.ItemGroups.Remove(itemGroup);
            db.SaveChanges();

            return Ok(itemGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemGroupExists(long id)
        {
            return db.ItemGroups.Count(e => e.ID == id) > 0;
        }
    }
}