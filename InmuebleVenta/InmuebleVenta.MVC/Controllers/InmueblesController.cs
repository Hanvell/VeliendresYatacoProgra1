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
using InmuebleVenta.Entities.IRepositories;

namespace InmuebleVenta.MVC.Controllers
{
    public class InmueblesController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public InmueblesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: Inmuebles
        public ActionResult Index()
        {
            //var inmuebles = db.Inmuebles.Include(i => i.Contrato).Include(i => i.Propietario).Include(i => i.Ubigeo);
            // return View(inmuebles.ToList());
            return View(_UnityOfWork.Inmueble.GetAll());

        }

        // GET: Inmuebles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //  Inmueble inmueble = db.Inmuebles.Find(id);
            Inmueble inmueble = _UnityOfWork.Inmueble.Get(id);

            if (inmueble == null)
            {
                return HttpNotFound();
            }
            return View(inmueble);
        }

        // GET: Inmuebles/Create
        public ActionResult Create()
        {
            ViewBag.InmuebleId = new SelectList(db.Contratos, "ContratoId", "NombreCliente");
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioDNI", "NombrePropietario");
            ViewBag.UbigeoId = new SelectList(db.Ubigeos, "UbigeoId", "UbigeoId");
            return View();
        }

        // POST: Inmuebles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InmuebleId,Estado,PrecioInmueble,DireccionInmueble,TipoInmuebleId,UbigeoId,PropietarioId,ContratoId,VisitaId")] Inmueble inmueble)
        {
            if (ModelState.IsValid)
            {
                // db.Inmuebles.Add(inmueble);
                _UnityOfWork.Inmueble.Add(inmueble);

                //  db.SaveChanges();
                _UnityOfWork.SaveChanges();
               
                return RedirectToAction("Index");
            }

            ViewBag.InmuebleId = new SelectList(db.Contratos, "ContratoId", "NombreCliente", inmueble.InmuebleId);
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioDNI", "NombrePropietario", inmueble.PropietarioId);
            ViewBag.UbigeoId = new SelectList(db.Ubigeos, "UbigeoId", "UbigeoId", inmueble.UbigeoId);
            return View(inmueble);
        }

        // GET: Inmuebles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Inmueble inmueble = db.Inmuebles.Find(id);
            Inmueble inmueble = _UnityOfWork.Inmueble.Get(id);
            if (inmueble == null)
            {
                return HttpNotFound();
            }
            ViewBag.InmuebleId = new SelectList(db.Contratos, "ContratoId", "NombreCliente", inmueble.InmuebleId);
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioDNI", "NombrePropietario", inmueble.PropietarioId);
            ViewBag.UbigeoId = new SelectList(db.Ubigeos, "UbigeoId", "UbigeoId", inmueble.UbigeoId);
            return View(inmueble);
        }

        // POST: Inmuebles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InmuebleId,Estado,PrecioInmueble,DireccionInmueble,TipoInmuebleId,UbigeoId,PropietarioId,ContratoId,VisitaId")] Inmueble inmueble)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(inmueble).State = EntityState.Modified;
                _UnityOfWork.StateModified(inmueble);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InmuebleId = new SelectList(db.Contratos, "ContratoId", "NombreCliente", inmueble.InmuebleId);
            ViewBag.PropietarioId = new SelectList(db.Propietarios, "PropietarioDNI", "NombrePropietario", inmueble.PropietarioId);
            ViewBag.UbigeoId = new SelectList(db.Ubigeos, "UbigeoId", "UbigeoId", inmueble.UbigeoId);
            return View(inmueble);
        }

        // GET: Inmuebles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

           // Inmueble inmueble = db.Inmuebles.Find(id);
            Inmueble inmueble = _UnityOfWork.Inmueble.Get(id);
            if (inmueble == null)
            {
                return HttpNotFound();
            }
            return View(inmueble);
        }

        // POST: Inmuebles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Inmueble inmueble = db.Inmuebles.Find(id);
            Inmueble inmueble = _UnityOfWork.Inmueble.Get(id);

            // db.Inmuebles.Remove(inmueble);
            _UnityOfWork.Inmueble.Delete(inmueble);
            //db.SaveChanges();
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // db.Dispose();
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
