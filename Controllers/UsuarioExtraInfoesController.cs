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
    public class UsuarioExtraInfoesController : Controller
    {
        private ModelFinancieraContainer db = new ModelFinancieraContainer();

        // GET: UsuarioExtraInfoes
        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

        // GET: UsuarioExtraInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioExtraInfo usuarioExtraInfo = db.Usuarios.Find(id);
            if (usuarioExtraInfo == null)
            {
                return HttpNotFound();
            }
            return View(usuarioExtraInfo);
        }

        // GET: UsuarioExtraInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioExtraInfoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,Apodo,Telefono,Email,EsActivo")] UsuarioExtraInfo usuarioExtraInfo)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuarioExtraInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuarioExtraInfo);
        }

        // GET: UsuarioExtraInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioExtraInfo usuarioExtraInfo = db.Usuarios.Find(id);
            if (usuarioExtraInfo == null)
            {
                return HttpNotFound();
            }
            return View(usuarioExtraInfo);
        }

        // POST: UsuarioExtraInfoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,Apodo,Telefono,Email,EsActivo")] UsuarioExtraInfo usuarioExtraInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioExtraInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuarioExtraInfo);
        }

        // GET: UsuarioExtraInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioExtraInfo usuarioExtraInfo = db.Usuarios.Find(id);
            if (usuarioExtraInfo == null)
            {
                return HttpNotFound();
            }
            return View(usuarioExtraInfo);
        }

        // POST: UsuarioExtraInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioExtraInfo usuarioExtraInfo = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuarioExtraInfo);
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
