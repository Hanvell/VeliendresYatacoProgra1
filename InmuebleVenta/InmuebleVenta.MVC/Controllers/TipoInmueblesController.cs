using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InmuebleVenta.Entities;
using InmuebleVenta.Persistence;

namespace InmuebleVenta.MVC.Controllers
{
    public class TipoInmueblesController : Controller
    {
        private InmuebleVentaDbContext db = new InmuebleVentaDbContext();

        // GET: TipoInmuebles
        public ActionResult Index()
        {
            var inmuebles = db.Inmuebles.Include(t => t.Contrato).Include(t => t.Propietario).Include(t => t.Ubigeo);
            return View(inmuebles.ToList());
        }

        // GET: TipoInmuebles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoInmueble tipoInmueble = db.Inmuebles.Find(id);
            if (tipoInmueble == null)
            {
                return HttpNotFound();
            }
            return View(tipoInmueble);
        }

        // GET: TipoInmuebles/Create
        public ActionResult Create()
        {
            ViewBag.InmuebleId = new SelectList(db.Contratos, "ContratoId", "NombreCliente");
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioDNI", "NombrePropietario");
            ViewBag.UbigeoId = new SelectList(db.Ubigeos, "UbigeoId", "UbigeoId");
            return View();
        }

        // POST: TipoInmuebles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InmuebleId,Estado,PrecioInmueble,DireccionInmueble,TipoInmuebleId,UbigeoId,PropietarioId,ContratoId,VisitaId,Descripcion,Tipo")] TipoInmueble tipoInmueble)
        {
            if (ModelState.IsValid)
            {
                db.Inmuebles.Add(tipoInmueble);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InmuebleId = new SelectList(db.Contratos, "ContratoId", "NombreCliente", tipoInmueble.InmuebleId);
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioDNI", "NombrePropietario", tipoInmueble.PropietarioId);
            ViewBag.UbigeoId = new SelectList(db.Ubigeos, "UbigeoId", "UbigeoId", tipoInmueble.UbigeoId);
            return View(tipoInmueble);
        }

        // GET: TipoInmuebles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoInmueble tipoInmueble = db.Inmuebles.Find(id);
            if (tipoInmueble == null)
            {
                return HttpNotFound();
            }
            ViewBag.InmuebleId = new SelectList(db.Contratos, "ContratoId", "NombreCliente", tipoInmueble.InmuebleId);
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioDNI", "NombrePropietario", tipoInmueble.PropietarioId);
            ViewBag.UbigeoId = new SelectList(db.Ubigeos, "UbigeoId", "UbigeoId", tipoInmueble.UbigeoId);
            return View(tipoInmueble);
        }

        // POST: TipoInmuebles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InmuebleId,Estado,PrecioInmueble,DireccionInmueble,TipoInmuebleId,UbigeoId,PropietarioId,ContratoId,VisitaId,Descripcion,Tipo")] TipoInmueble tipoInmueble)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoInmueble).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InmuebleId = new SelectList(db.Contratos, "ContratoId", "NombreCliente", tipoInmueble.InmuebleId);
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioDNI", "NombrePropietario", tipoInmueble.PropietarioId);
            ViewBag.UbigeoId = new SelectList(db.Ubigeos, "UbigeoId", "UbigeoId", tipoInmueble.UbigeoId);
            return View(tipoInmueble);
        }

        // GET: TipoInmuebles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoInmueble tipoInmueble = db.Inmuebles.Find(id);
            if (tipoInmueble == null)
            {
                return HttpNotFound();
            }
            return View(tipoInmueble);
        }

        // POST: TipoInmuebles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoInmueble tipoInmueble = db.Inmuebles.Find(id);
            db.Inmuebles.Remove(tipoInmueble);
            db.SaveChanges();
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
