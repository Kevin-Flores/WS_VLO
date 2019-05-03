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
    public class DetallePedidoesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/DetallePedidoes
        public IQueryable<DetallePedido> GetDetallePedidoes()
        {
            return db.DetallePedidoes;
        }

        // GET: api/DetallePedidoes/5
        [ResponseType(typeof(DetallePedido))]
        public IHttpActionResult GetDetallePedido(int id)
        {
            DetallePedido detallePedido = db.DetallePedidoes.Find(id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            return Ok(detallePedido);
        }

        // PUT: api/DetallePedidoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetallePedido(int id, DetallePedido detallePedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detallePedido.IdDetalle)
            {
                return BadRequest();
            }

            db.Entry(detallePedido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallePedidoExists(id))
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

        // POST: api/DetallePedidoes
        [ResponseType(typeof(DetallePedido))]
        public IHttpActionResult PostDetallePedido(DetallePedido detallePedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DetallePedidoes.Add(detallePedido);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = detallePedido.IdDetalle }, detallePedido);
        }

        // DELETE: api/DetallePedidoes/5
        [ResponseType(typeof(DetallePedido))]
        public IHttpActionResult DeleteDetallePedido(int id)
        {
            DetallePedido detallePedido = db.DetallePedidoes.Find(id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            db.DetallePedidoes.Remove(detallePedido);
            db.SaveChanges();

            return Ok(detallePedido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetallePedidoExists(int id)
        {
            return db.DetallePedidoes.Count(e => e.IdDetalle == id) > 0;
        }
    }
}