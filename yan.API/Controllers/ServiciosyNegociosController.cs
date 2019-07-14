using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using yan.Common.Models;
using yan.Domain.Models;

namespace yan.API.Controllers
{
    public class ServiciosyNegociosController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/ServiciosyNegocios
        public IQueryable<ServiciosyNegocios> GetServiciosyNegocios()
        {
            return db.ServiciosyNegocios;
        }

        // GET: api/ServiciosyNegocios/5
        [ResponseType(typeof(ServiciosyNegocios))]
        public async Task<IHttpActionResult> GetServiciosyNegocios(int id)
        {
            ServiciosyNegocios serviciosyNegocios = await db.ServiciosyNegocios.FindAsync(id);
            if (serviciosyNegocios == null)
            {
                return NotFound();
            }

            return Ok(serviciosyNegocios);
        }

        // PUT: api/ServiciosyNegocios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutServiciosyNegocios(int id, ServiciosyNegocios serviciosyNegocios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviciosyNegocios.ServiId)
            {
                return BadRequest();
            }

            db.Entry(serviciosyNegocios).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciosyNegociosExists(id))
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

        // POST: api/ServiciosyNegocios
        [ResponseType(typeof(ServiciosyNegocios))]
        public async Task<IHttpActionResult> PostServiciosyNegocios(ServiciosyNegocios serviciosyNegocios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiciosyNegocios.Add(serviciosyNegocios);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = serviciosyNegocios.ServiId }, serviciosyNegocios);
        }

        // DELETE: api/ServiciosyNegocios/5
        [ResponseType(typeof(ServiciosyNegocios))]
        public async Task<IHttpActionResult> DeleteServiciosyNegocios(int id)
        {
            ServiciosyNegocios serviciosyNegocios = await db.ServiciosyNegocios.FindAsync(id);
            if (serviciosyNegocios == null)
            {
                return NotFound();
            }

            db.ServiciosyNegocios.Remove(serviciosyNegocios);
            await db.SaveChangesAsync();

            return Ok(serviciosyNegocios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiciosyNegociosExists(int id)
        {
            return db.ServiciosyNegocios.Count(e => e.ServiId == id) > 0;
        }
    }
}