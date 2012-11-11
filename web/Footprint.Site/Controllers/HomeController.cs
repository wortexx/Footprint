using System.Collections.Generic;
using System.Web.Mvc;
using Footprint.Site.Models;
using Footprint.Site.Services.Statistics;

namespace Footprint.Site.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            if(!User.Identity.IsAuthenticated)
            {
                return View("Home");

            }
            else
            {
                ViewBag.Message = "Make your life green.....";

                var model = new StatisticsService().GetStatisticsForUser(User.Identity.Name);
                    

                return View(model);
            }
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
