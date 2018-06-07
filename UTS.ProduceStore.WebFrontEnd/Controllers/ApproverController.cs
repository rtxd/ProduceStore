using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UTS.ProduceStore.WebFrontEnd.Models;
using UTS.ProduceStore.Data;

namespace UTS.ProduceStore.WebFrontEnd.Controllers
{
    public class ApproverController : Controller
    {
        private ProduceStoreEntities db = new ProduceStoreEntities();

        // GET: Approver
        public ActionResult Index()
        {
            return View(db.Rules.ToList());
        }

        // GET: Approver/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data.Rule rule = db.Rules.Find(id);
            if (rule == null)
            {
                return HttpNotFound();
            }
            return View(rule);
        }

        // GET: Approver/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data.Rule rule = db.Rules.Find(id);
            if (rule == null)
            {
                return HttpNotFound();
            }
            return View(rule);
        }

        // POST: Approver/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RuleStatus")] Data.Rule rule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rule);
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
