using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UTS.ProduceStore.WebFrontEnd.Models;

namespace UTS.ProduceStore.WebFrontEnd.Controllers
{
    public class DataMaintainerController : Controller
    {
        private ProduceStoreEntities db = new ProduceStoreEntities();

        // GET: DataMaintainer
        public ActionResult Index()
        {
            return View(db.Produces.ToList());
        }

        // GET: DataMaintainer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produce produce = db.Produces.Find(id);
            if (produce == null)
            {
                return HttpNotFound();
            }
            return View(produce);
        }

        // GET: DataMaintainer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataMaintainer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProduceId,ProduceName,ProduceType,Season,Price,Stock,PluralName")] Produce produce)
        {
            if (ModelState.IsValid)
            {
                db.Produces.Add(produce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produce);
        }

        // GET: DataMaintainer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produce produce = db.Produces.Find(id);
            if (produce == null)
            {
                return HttpNotFound();
            }
            return View(produce);
        }

        // POST: DataMaintainer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProduceId,ProduceName,ProduceType,Season,Price,Stock,PluralName")] Produce produce)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produce);
        }

        // GET: DataMaintainer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produce produce = db.Produces.Find(id);
            if (produce == null)
            {
                return HttpNotFound();
            }
            return View(produce);
        }

        // POST: DataMaintainer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produce produce = db.Produces.Find(id);
            db.Produces.Remove(produce);
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
