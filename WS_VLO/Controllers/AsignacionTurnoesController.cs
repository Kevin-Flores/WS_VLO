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
    public class AsignacionTurnoesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/AsignacionTurnoes
        public IQueryable<AsignacionTurno> GetAsignacionTurnoes()
        {
            return db.AsignacionTurnoes;
        }

        // GET: api/AsignacionTurnoes/5
        [ResponseType(typeof(AsignacionTurno))]
        public IHttpActionResult GetAsignacionTurno(int id)
        {
            AsignacionTurno asignacionTurno = db.AsignacionTurnoes.Find(id);
            if (asignacionTurno == null)
            {
                return NotFound();
            }

            return Ok(asignacionTurno);
        }

        // PUT: api/AsignacionTurnoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAsignacionTurno(int id, AsignacionTurno asignacionTurno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asignacionTurno.IdAsignacion)
            {
                return BadRequest();
            }

            db.Entry(asignacionTurno).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignacionTurnoExists(id))
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

        // POST: api/AsignacionTurnoes
        [ResponseType(typeof(AsignacionTurno))]
        public IHttpActionResult PostAsignacionTurno(AsignacionTurno asignacionTurno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AsignacionTurnoes.Add(asignacionTurno);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = asignacionTurno.IdAsignacion }, asignacionTurno);
        }

        // DELETE: api/AsignacionTurnoes/5
        [ResponseType(typeof(AsignacionTurno))]
        public IHttpActionResult DeleteAsignacionTurno(int id)
        {
            AsignacionTurno asignacionTurno = db.AsignacionTurnoes.Find(id);
            if (asignacionTurno == null)
            {
                return NotFound();
            }

            db.AsignacionTurnoes.Remove(asignacionTurno);
            db.SaveChanges();

            return Ok(asignacionTurno);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AsignacionTurnoExists(int id)
        {
            return db.AsignacionTurnoes.Count(e => e.IdAsignacion == id) > 0;
        }
    }
}