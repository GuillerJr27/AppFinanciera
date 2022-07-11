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
    public class MovimientoCuentasController : Controller
    {
        private ModelFinancieraContainer db = new ModelFinancieraContainer();

        // GET: MovimientoCuentas
        public ActionResult Index()
        {
            var movimientoCuentas = db.MovimientoCuentas.Include(m => m.TipoDeGasto).Include(m => m.CuentaUsuario);
            return View(movimientoCuentas.ToList());
        }

        // GET: MovimientoCuentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimientoCuentas movimientoCuentas = db.MovimientoCuentas.Find(id);
            if (movimientoCuentas == null)
            {
                return HttpNotFound();
            }
            return View(movimientoCuentas);
        }

        // GET: MovimientoCuentas/Create
        public ActionResult Create()
        {
            ViewBag.TipoDeGastoId = new SelectList(db.TipoDeGastos, "Id", "Nombre");
            ViewBag.CuentaUsuarioId = new SelectList(db.CuentaUsuarios, "Id", "NombreCuenta");
            return View();
        }

        // POST: MovimientoCuentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Comentarios,Monto,TipoDeGastoId,CuentaUsuarioId")] MovimientoCuentas movimientoCuentas)
        {
            if (ModelState.IsValid)
            {
                db.MovimientoCuentas.Add(movimientoCuentas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoDeGastoId = new SelectList(db.TipoDeGastos, "Id", "Nombre", movimientoCuentas.TipoDeGastoId);
            ViewBag.CuentaUsuarioId = new SelectList(db.CuentaUsuarios, "Id", "NombreCuenta", movimientoCuentas.CuentaUsuarioId);
            return View(movimientoCuentas);
        }

        // GET: MovimientoCuentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimientoCuentas movimientoCuentas = db.MovimientoCuentas.Find(id);
            if (movimientoCuentas == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoDeGastoId = new SelectList(db.TipoDeGastos, "Id", "Nombre", movimientoCuentas.TipoDeGastoId);
            ViewBag.CuentaUsuarioId = new SelectList(db.CuentaUsuarios, "Id", "NombreCuenta", movimientoCuentas.CuentaUsuarioId);
            return View(movimientoCuentas);
        }

        // POST: MovimientoCuentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Comentarios,Monto,TipoDeGastoId,CuentaUsuarioId")] MovimientoCuentas movimientoCuentas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimientoCuentas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoDeGastoId = new SelectList(db.TipoDeGastos, "Id", "Nombre", movimientoCuentas.TipoDeGastoId);
            ViewBag.CuentaUsuarioId = new SelectList(db.CuentaUsuarios, "Id", "NombreCuenta", movimientoCuentas.CuentaUsuarioId);
            return View(movimientoCuentas);
        }

        // GET: MovimientoCuentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimientoCuentas movimientoCuentas = db.MovimientoCuentas.Find(id);
            if (movimientoCuentas == null)
            {
                return HttpNotFound();
            }
            return View(movimientoCuentas);
        }

        // POST: MovimientoCuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovimientoCuentas movimientoCuentas = db.MovimientoCuentas.Find(id);
            db.MovimientoCuentas.Remove(movimientoCuentas);
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
