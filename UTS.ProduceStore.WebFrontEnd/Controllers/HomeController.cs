using System.Web.Mvc;
using UTS.ProduceStore.DomainLogic;
using UTS.ProduceStore.WebFrontEnd.Models;

namespace UTS.ProduceStore.WebFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Index page
        /// </summary>
        /// <returns>Index View</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Takes the users questions and finds an answer
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Returns a view with an answer</returns>
        [HttpPost]
        public ActionResult Answer(HomeModel model)
        {
            RuleEngine ruleEngine = new RuleEngine();
            ViewBag.Answer = ruleEngine.Answer(model.Question);
            return View("Index", model);
        }
    }
}