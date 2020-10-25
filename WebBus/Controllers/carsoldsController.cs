using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBus.Models;

namespace WebBus.Controllers
{
    public class carsoldsController : Controller
    {
        private CarDatabaseEntities db = new CarDatabaseEntities();

        // GET: carsolds
        public ActionResult Index()
        {
            return View(db.carsold.ToList());
        }

        // GET: carsolds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carsold carsold = db.carsold.Find(id);
            if (carsold == null)
            {
                return HttpNotFound();
            }
            return View(carsold);
        }

        // GET: carsolds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: carsolds/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Matricule,Datesold,Name,Price")] carsold carsold)
        {
            if (ModelState.IsValid)
            {
                db.carsold.Add(carsold);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carsold);
        }

        // GET: carsolds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carsold carsold = db.carsold.Find(id);
            if (carsold == null)
            {
                return HttpNotFound();
            }
            return View(carsold);
        }

        // POST: carsolds/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Matricule,Datesold,Name,Price")] carsold carsold)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carsold).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carsold);
        }

        // GET: carsolds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carsold carsold = db.carsold.Find(id);
            if (carsold == null)
            {
                return HttpNotFound();
            }
            return View(carsold);
        }

        // POST: carsolds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            carsold carsold = db.carsold.Find(id);
            db.carsold.Remove(carsold);
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
