using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Http.Description;
using WS_VLO.Models;

namespace WS_VLO.Controllers
{
    public class TurnosController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Turnos
        public IQueryable<Turnos> GetTurnos()
        {
            return db.Turnos;
        }

        // GET: api/Turnos/5
        [ResponseType(typeof(Turnos))]
        public IHttpActionResult GetTurnos(int id)
        {
            //Turnos turnos = db.Turnos.Find(id);
            //if (turnos == null)
            //{
            //    return NotFound();
            //}
            List<AsignacionTurno> TurnosAsignados = db.AsignacionTurnoes.ToList();
            List<Turnos> SoloTurnos = db.Turnos.ToList();
            var query = (from TA in TurnosAsignados
                         where TA.IdUser == id
                         join SA in SoloTurnos on TA.IdTurno equals SA.IdTurno
                         select new
                         {
                             TA.Fecha,
                             SA.IdTurno,
                             SA.Nombre,
                             SA.HoraInicial,
                             SA.HoraFinal
                         }).ToList();

            DateTime Fecha1 = DateTime.Now;
            DateTime Fecha2 = Fecha1.AddDays(1);
            DateTime Fecha3 = Fecha1.AddDays(2);
            DateTime Fecha4 = Fecha1.AddDays(3);
            DateTime Fecha5 = Fecha1.AddDays(4);

            var mandar = from q in query
                            where q.Fecha == Fecha1.ToString("yyyy-MM-dd") ||
                            q.Fecha == Fecha2.ToString("yyyy-MM-dd") || q.Fecha == Fecha3.ToString("yyyy-MM-dd") ||
                            q.Fecha == Fecha4.ToString("yyyy-MM-dd") || q.Fecha == Fecha5.ToString("yyyy-MM-dd")
                         select q;

            var listo = JsonConvert.SerializeObject(mandar);
            List<MTurnos> enviar = JsonConvert.DeserializeObject<List<MTurnos>>(listo);
            
          
            return Ok(enviar);
        }

        // PUT: api/Turnos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTurnos(int id, Turnos turnos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != turnos.IdTurno)
            {
                return BadRequest();
            }

            db.Entry(turnos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurnosExists(id))
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

        // POST: api/Turnos
        [ResponseType(typeof(Turnos))]
        public IHttpActionResult PostTurnos(Turnos turnos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Turnos.Add(turnos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = turnos.IdTurno }, turnos);
        }

        // DELETE: api/Turnos/5
        [ResponseType(typeof(Turnos))]
        public IHttpActionResult DeleteTurnos(int id)
        {
            Turnos turnos = db.Turnos.Find(id);
            if (turnos == null)
            {
                return NotFound();
            }

            db.Turnos.Remove(turnos);
            db.SaveChanges();

            return Ok(turnos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TurnosExists(int id)
        {
            return db.Turnos.Count(e => e.IdTurno == id) > 0;
        }
    }
}