using System.Collections.Generic;
using System.Web.Mvc;
using Footprint.Site.Models;

namespace Footprint.Site.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Message = "Make your life green.....";

            var model = new Consumer
                {
                    Statistic = new List<StatisticItemModel>
                        {
                            new StatisticItemModel
                                {
                                    Consumer = "Car",
                                    Usage = 10.34M,
                                    Norm = 4.4M
                                },
                            new StatisticItemModel
                                {
                                    Consumer = "Printer",
                                    Usage = 4.34M,
                                    Norm = 5.4M
                                }
                        }
                };


            return View(model);
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
