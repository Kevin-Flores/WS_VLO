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
using System.Data.Entity.Migrations;

namespace WS_VLO.Controllers
{
    public class MesasController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Mesas
        public IQueryable<Mesas> GetMesas()
        {
            return db.Mesas;
        }

        // GET: api/Mesas/5
        [ResponseType(typeof(Mesas))]
        public IHttpActionResult GetMesas(int id)
        {
            Mesas mesas = db.Mesas.Find(id);
            if (mesas == null)
            {
                return NotFound();
            }

            return Ok(mesas);
        }

        // PUT: api/Mesas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMesas( Mesas mesas)

        {
            /* if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }*/

            Pedido pd = (from p in db.Pedidoes where p.IdMesa == mesas.IdMesa select p).FirstOrDefault();
            //pd.FirstOrDefault();
            DetallePedido pd2 = (from pp in db.DetallePedidoes where pp.IdPedido == pd.IdPedido select pp).FirstOrDefault();

            var mesaId = from m in db.Mesas
                         where m.IdMesa == mesas.IdMesa
                         select m;

            if(pd2 != null)
            {
                return NotFound();
            }

            if (mesaId.FirstOrDefault().IdMesa != mesas.IdMesa)
            {
                return BadRequest();
            }
            mesas.NumMesa = mesas.NumMesa.Replace("Mesa ", "");
            db.Set<Mesas>().AddOrUpdate(mesas);
            //db.Entry(mesas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MesasExists(mesaId.FirstOrDefault().IdMesa))
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


        /*
    [ResponseType(typeof(void))]
    public IHttpActionResult PutMesas(int id, Mesas mesas)

    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != mesas.IdMesa)
        {
            return BadRequest();
        }

        db.Entry(mesas).State = EntityState.Modified;

        try
        {
            db.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MesasExists(id))
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
    */
        // POST: api/Mesas
        [ResponseType(typeof(Mesas))]
        public IHttpActionResult PostMesas(Mesas mesas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mesas.Add(mesas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mesas.IdMesa }, mesas);
        }

        // DELETE: api/Mesas/5
        [ResponseType(typeof(Mesas))]
        public IHttpActionResult DeleteMesas(int id)
        {
            Mesas mesas = db.Mesas.Find(id);
            if (mesas == null)
            {
                return NotFound();
            }

            db.Mesas.Remove(mesas);
            db.SaveChanges();

            return Ok(mesas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MesasExists(int id)
        {
            return db.Mesas.Count(e => e.IdMesa == id) > 0;
        }
    }
}