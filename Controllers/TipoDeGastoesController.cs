using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppFinanciera.Models;

namespace AppFinanciera.Controllers
{
    public class TipoDeGastoesController : Controller
    {
        private ModelFinancieraContainer db = new ModelFinancieraContainer();

        // GET: TipoDeGastoes
        public ActionResult Index()
        {
            return View(db.TipoDeGastos.ToList());
        }

        // GET: TipoDeGastoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeGasto tipoDeGasto = db.TipoDeGastos.Find(id);
            if (tipoDeGasto == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeGasto);
        }

        // GET: TipoDeGastoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDeGastoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,EsActivo")] TipoDeGasto tipoDeGasto)
        {
            if (ModelState.IsValid)
            {
                db.TipoDeGastos.Add(tipoDeGasto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDeGasto);
        }

        // GET: TipoDeGastoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeGasto tipoDeGasto = db.TipoDeGastos.Find(id);
            if (tipoDeGasto == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeGasto);
        }

        // POST: TipoDeGastoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,EsActivo")] TipoDeGasto tipoDeGasto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeGasto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDeGasto);
        }

        // GET: TipoDeGastoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeGasto tipoDeGasto = db.TipoDeGastos.Find(id);
            if (tipoDeGasto == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeGasto);
        }

        // POST: TipoDeGastoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDeGasto tipoDeGasto = db.TipoDeGastos.Find(id);
            db.TipoDeGastos.Remove(tipoDeGasto);
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
