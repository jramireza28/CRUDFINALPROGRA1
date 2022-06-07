using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDFINALPROGRA1.Models;

namespace CRUDFINALPROGRA1.Controllers
{
    public class tb_relojesController : Controller
    {
        private Relojeria1Entities db = new Relojeria1Entities();

        // GET: tb_relojes
        public ActionResult Index()
        {
            return View(db.tb_relojes.ToList());
        }

        // GET: tb_relojes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_relojes tb_relojes = db.tb_relojes.Find(id);
            if (tb_relojes == null)
            {
                return HttpNotFound();
            }
            return View(tb_relojes);
        }

        // GET: tb_relojes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_relojes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRelojes,Nombre,Modelo,Marca,Mecanismo,Genero,Precio,Correa,Color,Fecha")] tb_relojes tb_relojes)
        {
            if (ModelState.IsValid)
            {
                db.tb_relojes.Add(tb_relojes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_relojes);
        }

        // GET: tb_relojes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_relojes tb_relojes = db.tb_relojes.Find(id);
            if (tb_relojes == null)
            {
                return HttpNotFound();
            }
            return View(tb_relojes);
        }

        // POST: tb_relojes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRelojes,Nombre,Modelo,Marca,Mecanismo,Genero,Precio,Correa,Color,Fecha")] tb_relojes tb_relojes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_relojes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_relojes);
        }

        // GET: tb_relojes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_relojes tb_relojes = db.tb_relojes.Find(id);
            if (tb_relojes == null)
            {
                return HttpNotFound();
            }
            return View(tb_relojes);
        }

        // POST: tb_relojes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_relojes tb_relojes = db.tb_relojes.Find(id);
            db.tb_relojes.Remove(tb_relojes);
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
