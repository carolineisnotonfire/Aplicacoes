using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{

    public class CarrosController : ApiController
    {
        private Model1 db = new Model1();
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        // GET: api/Carros
        public IQueryable<Carros> GetCarros()
        {
            return db.Carros;
        }

        // GET: api/Carros/5
        [ResponseType(typeof(Carros))]
        public IHttpActionResult GetCarros(int id)
        {
            Carros carros = db.Carros.Find(id);
            if (carros == null)
            {
                return NotFound();
            }

            return Ok(carros);
        }

        // PUT: api/Carros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarros(int id, Carros carros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carros.Id)
            {
                return BadRequest();
            }

            db.Entry(carros).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarrosExists(id))
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

        // POST: api/Carros
        [ResponseType(typeof(Carros))]
        public IHttpActionResult PostCarros(Carros carros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Carros.Add(carros);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carros.Id }, carros);
        }

        // DELETE: api/Carros/5
        [ResponseType(typeof(Carros))]
        public IHttpActionResult DeleteCarros(int id)
        {
            Carros carros = db.Carros.Find(id);
            if (carros == null)
            {
                return NotFound();
            }

            db.Carros.Remove(carros);
            db.SaveChanges();

            return Ok(carros);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarrosExists(int id)
        {
            return db.Carros.Count(e => e.Id == id) > 0;
        }
    }
}