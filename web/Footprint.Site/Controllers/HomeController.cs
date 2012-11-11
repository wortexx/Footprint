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
                                    ConsumerType = ConsumerType.Vehicle,
                                    Usage = 10.34M,
                                    Norm = 4.4M
                                },
                            new StatisticItemModel
                                {
                                    Consumer = "Printer",
                                    ConsumerType = ConsumerType.Printer,
                                    Usage = 18.34M,
                                    Norm = 5.4M
                                },
                           new StatisticItemModel
                                {
                                    Consumer = "Water",
                                    ConsumerType = ConsumerType.Water,
                                    Usage = 5.34M,
                                    Norm = 5.4M
                                },
                           new StatisticItemModel
                                {
                                    Consumer = "Electricity",
                                    ConsumerType = ConsumerType.Electricity,
                                    Usage = 13.34M,
                                    Norm = 10.4M
                                },
                           new StatisticItemModel
                                {
                                    Consumer = "Heating",
                                    ConsumerType = ConsumerType.Heating,
                                    Usage = 15.34M,
                                    Norm = 34.4M
                                },
                           new StatisticItemModel
                                {
                                    Consumer = "Cooling",
                                    ConsumerType = ConsumerType.Cooling,
                                    Usage = 12.34M,
                                    Norm = 12.4M
                                },
                           new StatisticItemModel
                                {
                                    Consumer = "Plastic",
                                    ConsumerType = ConsumerType.Plastic,
                                    Usage = 20.34M,
                                    Norm = 2.4M
                                },
                           new StatisticItemModel
                                {
                                    Consumer = "Printer",
                                    ConsumerType = ConsumerType.Printer,
                                    Usage = 10.34M,
                                    Norm = 5.4M
                                },
                       
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
