using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTS.ProduceStore.DomainLogic;
using UTS.ProduceStore.WebFrontEnd.Models;

namespace UTS.ProduceStore.WebFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpPost]
        public ActionResult Answer(HomeModel model)
        {
            RuleEngine ruleEngine = new RuleEngine();
            ViewBag.Answer = ruleEngine.Answer(model.Question);
            return View("Index", model);
        }
    }
}