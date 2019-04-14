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
using WS_VLO.Models;

namespace WS_VLO.Controllers
{
    public class TipoMenusController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/TipoMenus
        public IQueryable<TipoMenu> GetTipoMenus()
        {
            return db.TipoMenus;
        }

        // GET: api/TipoMenus/5
        [ResponseType(typeof(TipoMenu))]
        public IHttpActionResult GetTipoMenu(int id)
        {
            TipoMenu tipoMenu = db.TipoMenus.Find(id);
            if (tipoMenu == null)
            {
                return NotFound();
            }

            return Ok(tipoMenu);
        }

        // PUT: api/TipoMenus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoMenu(int id, TipoMenu tipoMenu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoMenu.IdTipoMenu)
            {
                return BadRequest();
            }

            db.Entry(tipoMenu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoMenuExists(id))
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

        // POST: api/TipoMenus
        [ResponseType(typeof(TipoMenu))]
        public IHttpActionResult PostTipoMenu(TipoMenu tipoMenu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoMenus.Add(tipoMenu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoMenu.IdTipoMenu }, tipoMenu);
        }

        // DELETE: api/TipoMenus/5
        [ResponseType(typeof(TipoMenu))]
        public IHttpActionResult DeleteTipoMenu(int id)
        {
            TipoMenu tipoMenu = db.TipoMenus.Find(id);
            if (tipoMenu == null)
            {
                return NotFound();
            }

            db.TipoMenus.Remove(tipoMenu);
            db.SaveChanges();

            return Ok(tipoMenu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoMenuExists(int id)
        {
            return db.TipoMenus.Count(e => e.IdTipoMenu == id) > 0;
        }
    }
}