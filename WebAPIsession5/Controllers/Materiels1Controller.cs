using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAPIsession5.Models;

namespace WebAPIsession5.Controllers
{
    public class Materiels1Controller : Controller
    {
        private WebAPIsession5BDContext db = new WebAPIsession5BDContext();

        // GET: Materiels1
        public ActionResult Index()
        {
            var materiels = db.Materiels.Include(m => m.Departement);
            return View(materiels.ToList());
        }

        // GET: Materiels1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materiel materiel = db.Materiels.Find(id);
            if (materiel == null)
            {
                return HttpNotFound();
            }
            return View(materiel);
        }

        // GET: Materiels1/Create
        public ActionResult Create()
        {
            ViewBag.DepartementId = new SelectList(db.Departements, "DepartementId", "Name");
            return View();
        }

        // POST: Materiels1/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaterielId,Libille,Number,DepartementId")] Materiel materiel)
        {
            if (ModelState.IsValid)
            {
                db.Materiels.Add(materiel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartementId = new SelectList(db.Departements, "DepartementId", "Name", materiel.DepartementId);
            return View(materiel);
        }

        // GET: Materiels1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materiel materiel = db.Materiels.Find(id);
            if (materiel == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartementId = new SelectList(db.Departements, "DepartementId", "Name", materiel.DepartementId);
            return View(materiel);
        }

        // POST: Materiels1/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaterielId,Libille,Number,DepartementId")] Materiel materiel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materiel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartementId = new SelectList(db.Departements, "DepartementId", "Name", materiel.DepartementId);
            return View(materiel);
        }

        // GET: Materiels1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materiel materiel = db.Materiels.Find(id);
            if (materiel == null)
            {
                return HttpNotFound();
            }
            return View(materiel);
        }

        // POST: Materiels1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Materiel materiel = db.Materiels.Find(id);
            db.Materiels.Remove(materiel);
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
