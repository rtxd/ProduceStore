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
    [Authorize(Roles = "Approver")]
    public class ApproverController : Controller
    {
        
        private RulesService service = new RulesService();
        // GET: Approver
        public ActionResult Index()
        {
            return View(service.GetRulesByStatus("Pending"));
        }

        public ActionResult Approve(int? id)
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
            rule.RuleStatus = "Approved";
            service.Update(rule);
            return RedirectToAction("Index");
        }

        public ActionResult Reject(int? id)
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
            rule.RuleStatus = "Rejected";
            service.Update(rule);
            return RedirectToAction("Index");
        }
        
        
        // GET: Approver/Details/5
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

        
    }
}
