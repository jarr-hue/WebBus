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
    public class providersController : Controller
    {
        private CarDatabaseEntities db = new CarDatabaseEntities();

        // GET: providers
        public ActionResult Index()
        {
            return View(db.provider.ToList());
        }

        // GET: providers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            provider provider = db.provider.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        // GET: providers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: providers/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Phone,Mail,Adress")] provider provider)
        {
            if (ModelState.IsValid)
            {
                db.provider.Add(provider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(provider);
        }

        // GET: providers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            provider provider = db.provider.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        // POST: providers/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Phone,Mail,Adress")] provider provider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(provider);
        }

        // GET: providers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            provider provider = db.provider.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        // POST: providers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            provider provider = db.provider.Find(id);
            db.provider.Remove(provider);
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
