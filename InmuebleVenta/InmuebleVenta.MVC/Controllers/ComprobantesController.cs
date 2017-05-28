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
    public class ComprobantesController : Controller
    {
        private InmuebleVentaDbContext db = new InmuebleVentaDbContext();

        // GET: Comprobantes
        public ActionResult Index()
        {
            return View(db.Comprobantes.ToList());
        }

        // GET: Comprobantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comprobante comprobante = db.Comprobantes.Find(id);
            if (comprobante == null)
            {
                return HttpNotFound();
            }
            return View(comprobante);
        }

        // GET: Comprobantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comprobantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComprobanteId,Fecha,Monto,ContratoResarvaId,ContratoAlquilerId")] Comprobante comprobante)
        {
            if (ModelState.IsValid)
            {
                db.Comprobantes.Add(comprobante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comprobante);
        }

        // GET: Comprobantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comprobante comprobante = db.Comprobantes.Find(id);
            if (comprobante == null)
            {
                return HttpNotFound();
            }
            return View(comprobante);
        }

        // POST: Comprobantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComprobanteId,Fecha,Monto,ContratoResarvaId,ContratoAlquilerId")] Comprobante comprobante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comprobante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comprobante);
        }

        // GET: Comprobantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comprobante comprobante = db.Comprobantes.Find(id);
            if (comprobante == null)
            {
                return HttpNotFound();
            }
            return View(comprobante);
        }

        // POST: Comprobantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comprobante comprobante = db.Comprobantes.Find(id);
            db.Comprobantes.Remove(comprobante);
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
