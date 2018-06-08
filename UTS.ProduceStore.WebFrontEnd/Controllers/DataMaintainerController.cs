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
using UTS.ProduceStore.DomainLogic;

namespace UTS.ProduceStore.WebFrontEnd.Controllers
{
    [Authorize(Roles = "DataMaintainer")]
    public class DataMaintainerController : Controller
    {
        private ProduceService service = new ProduceService();
        // GET: DataMaintainer
        public ActionResult Index()
        {
            //throw new NotImplementedException();
            return View(service.AllProduce());
        }

        // GET: DataMaintainer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produce produce = service.GetProduceById((int)id);
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
                service.Add(produce);
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
            Produce produce = service.GetProduceById((int)id);
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
                service.Update(produce);
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
            Produce produce = service.GetProduceById((int)id);
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
            Produce produce = service.GetProduceById(id);
            service.Delete(produce);
            return RedirectToAction("Index");
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
