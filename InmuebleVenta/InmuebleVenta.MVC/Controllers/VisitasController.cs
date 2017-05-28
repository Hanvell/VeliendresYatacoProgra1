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
    public class VisitasController : Controller
    {
        private InmuebleVentaDbContext db = new InmuebleVentaDbContext();

        // GET: Visitas
        public ActionResult Index()
        {
            var visitas = db.Visitas.Include(v => v.Cliente).Include(v => v.Empleado);
            return View(visitas.ToList());
        }

        // GET: Visitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visitas.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // GET: Visitas/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteDNI", "NombreCliente");
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoDNI", "NombreEmpleado");
            return View();
        }

        // POST: Visitas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VisitaId,FechaVisita,EmpleadoId,ClienteId")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                db.Visitas.Add(visita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteDNI", "NombreCliente", visita.ClienteId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoDNI", "NombreEmpleado", visita.EmpleadoId);
            return View(visita);
        }

        // GET: Visitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visitas.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteDNI", "NombreCliente", visita.ClienteId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoDNI", "NombreEmpleado", visita.EmpleadoId);
            return View(visita);
        }

        // POST: Visitas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VisitaId,FechaVisita,EmpleadoId,ClienteId")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteDNI", "NombreCliente", visita.ClienteId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoDNI", "NombreEmpleado", visita.EmpleadoId);
            return View(visita);
        }

        // GET: Visitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visitas.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // POST: Visitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visita visita = db.Visitas.Find(id);
            db.Visitas.Remove(visita);
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
