using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using yan.Backend.Models;
using yan.Common.Models;

namespace yan.Backend.Controllers
{
    public class ServiciosyNegociosController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: ServiciosyNegocios
        public async Task<ActionResult> Index()
        {
            return View(await db.ServiciosyNegocios.ToListAsync());
        }

        // GET: ServiciosyNegocios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiciosyNegocios serviciosyNegocios = await db.ServiciosyNegocios.FindAsync(id);
            if (serviciosyNegocios == null)
            {
                return HttpNotFound();
            }
            return View(serviciosyNegocios);
        }

        // GET: ServiciosyNegocios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiciosyNegocios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ServiId,ServiceName,Adreess,PageContact,Phone,PublishOn,Description,TypeService,ImagePath")] ServiciosyNegocios serviciosyNegocios)
        {
            if (ModelState.IsValid)
            {
                db.ServiciosyNegocios.Add(serviciosyNegocios);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(serviciosyNegocios);
        }

        // GET: ServiciosyNegocios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiciosyNegocios serviciosyNegocios = await db.ServiciosyNegocios.FindAsync(id);
            if (serviciosyNegocios == null)
            {
                return HttpNotFound();
            }
            return View(serviciosyNegocios);
        }

        // POST: ServiciosyNegocios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ServiId,ServiceName,Adreess,PageContact,Phone,PublishOn,Description,TypeService,ImagePath")] ServiciosyNegocios serviciosyNegocios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviciosyNegocios).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(serviciosyNegocios);
        }

        // GET: ServiciosyNegocios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiciosyNegocios serviciosyNegocios = await db.ServiciosyNegocios.FindAsync(id);
            if (serviciosyNegocios == null)
            {
                return HttpNotFound();
            }
            return View(serviciosyNegocios);
        }

        // POST: ServiciosyNegocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ServiciosyNegocios serviciosyNegocios = await db.ServiciosyNegocios.FindAsync(id);
            db.ServiciosyNegocios.Remove(serviciosyNegocios);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
