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
    [Authorize(Roles = "Editor")]
    public class EditorController : Controller
    {
        private RulesService service = new RulesService();

        // GET: Editor
        public ActionResult Index()
        {
            return View(
                new EditorViewModel
                {
                    PendingRules = service.GetRulesByStatus("Pending"),
                    RejectedRules = service.GetRulesByStatus("Rejected")

                }
            ); 
        }

        // GET: Editor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data.Rule rule = service.GetRuleById((int)id);
            if (rule == null)
            {
                return HttpNotFound();
            }
            return View(rule);
        }
        
        // GET: Editor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Editor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RuleId,RegularExpression,RegExGroup,Query,RuleStatus,LastUpdateUser")] Data.Rule rule)
        {
            if (ModelState.IsValid)
            {
                rule.LastUpdateUser = User.Identity.Name;
                service.Add(rule);
                return RedirectToAction("Index");
            }

            return View(rule);
        }

        // GET: Editor/Edit/5        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data.Rule rule = service.GetRuleById((int)id);
            if (rule == null)
            {
                return HttpNotFound();
            }
            return View(rule);
        }
        
        // POST: Editor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RuleId,RegularExpression,RegExGroup,Query,RuleStatus,LastUpdateUser")] Data.Rule rule)
        {
            if (ModelState.IsValid)
            {
                rule.LastUpdateUser = User.Identity.Name;
                rule.RuleStatus = "Pending";
                service.Update(rule);
                return RedirectToAction("Index");
            }
            return View(rule);
        }

        // GET: Editor/Delete/5
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data.Rule rule = service.GetRuleById((int)id);
            if (rule == null)
            {
                return HttpNotFound();
            }
            return View(rule);
        }
        
        // POST: Editor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Data.Rule rule = service.GetRuleById(id);
            service.Delete(rule);
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
