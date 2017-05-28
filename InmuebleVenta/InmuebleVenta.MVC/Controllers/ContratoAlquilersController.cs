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
    public class ContratoAlquilersController : Controller
    {
        private InmuebleVentaDbContext db = new InmuebleVentaDbContext();

        // GET: ContratoAlquilers
        public ActionResult Index()
        {
            var contratos = db.Contratos.Include(c => c.Cliente).Include(c => c.Empleado);
            return View(contratos.ToList());
        }

        // GET: ContratoAlquilers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoAlquiler contratoAlquiler = db.Contratos.Find(id);
            if (contratoAlquiler == null)
            {
                return HttpNotFound();
            }
            return View(contratoAlquiler);
        }

        // GET: ContratoAlquilers/Create
        public ActionResult Create()
        {
            ViewBag.ClienteDNI = new SelectList(db.Clientes, "ClienteDNI", "NombreCliente");
            ViewBag.EmpleadoDNI = new SelectList(db.Empleados, "EmpleadoDNI", "NombreEmpleado");
            return View();
        }

        // POST: ContratoAlquilers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContratoId,Fecha,ClienteDNI,NombreCliente,ApeCliente,PropietarioDNI,ApePropietario,NombrePropietario,InmuebleId,PrecioInmueble,EmpleadoDNI,NombreEmpleado,ApeEmpleado,CantMeses,MontoMensual")] ContratoAlquiler contratoAlquiler)
        {
            if (ModelState.IsValid)
            {
                db.Contratos.Add(contratoAlquiler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteDNI = new SelectList(db.Clientes, "ClienteDNI", "NombreCliente", contratoAlquiler.ClienteDNI);
            ViewBag.EmpleadoDNI = new SelectList(db.Empleados, "EmpleadoDNI", "NombreEmpleado", contratoAlquiler.EmpleadoDNI);
            return View(contratoAlquiler);
        }

        // GET: ContratoAlquilers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoAlquiler contratoAlquiler = db.Contratos.Find(id);
            if (contratoAlquiler == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteDNI = new SelectList(db.Clientes, "ClienteDNI", "NombreCliente", contratoAlquiler.ClienteDNI);
            ViewBag.EmpleadoDNI = new SelectList(db.Empleados, "EmpleadoDNI", "NombreEmpleado", contratoAlquiler.EmpleadoDNI);
            return View(contratoAlquiler);
        }

        // POST: ContratoAlquilers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContratoId,Fecha,ClienteDNI,NombreCliente,ApeCliente,PropietarioDNI,ApePropietario,NombrePropietario,InmuebleId,PrecioInmueble,EmpleadoDNI,NombreEmpleado,ApeEmpleado,CantMeses,MontoMensual")] ContratoAlquiler contratoAlquiler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contratoAlquiler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteDNI = new SelectList(db.Clientes, "ClienteDNI", "NombreCliente", contratoAlquiler.ClienteDNI);
            ViewBag.EmpleadoDNI = new SelectList(db.Empleados, "EmpleadoDNI", "NombreEmpleado", contratoAlquiler.EmpleadoDNI);
            return View(contratoAlquiler);
        }

        // GET: ContratoAlquilers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoAlquiler contratoAlquiler = db.Contratos.Find(id);
            if (contratoAlquiler == null)
            {
                return HttpNotFound();
            }
            return View(contratoAlquiler);
        }

        // POST: ContratoAlquilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContratoAlquiler contratoAlquiler = db.Contratos.Find(id);
            db.Contratos.Remove(contratoAlquiler);
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
