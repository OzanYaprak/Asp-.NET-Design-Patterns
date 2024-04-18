using DesignPattern.Iterator.Models;
using DesignPattern.Iterator.Movers;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Iterator.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            VisitRouteMover visitRouteMover = new VisitRouteMover();
            List<string> routes = new List<string>();

            visitRouteMover.AddVisitRoute(new VisitRoute { CountryName = "Almanya", CityName = "Berlin", VisitPlaceName = "Berlin Kapısı" });
            visitRouteMover.AddVisitRoute(new VisitRoute { CountryName = "Fransa", CityName = "Paris", VisitPlaceName = "Eifel" });
            visitRouteMover.AddVisitRoute(new VisitRoute { CountryName = "İtalya", CityName = "Venedik", VisitPlaceName = "Gondol" });
            visitRouteMover.AddVisitRoute(new VisitRoute { CountryName = "İtalya", CityName = "Roma", VisitPlaceName = "Collesium" });
            visitRouteMover.AddVisitRoute(new VisitRoute { CountryName = "Mısır", CityName = "Kahire", VisitPlaceName = "Pyramids" });

            var iterator = visitRouteMover.CreateIterator();
            while (iterator.MoveNext())
            {
                routes.Add(iterator.CurrentItem.CountryName + " " + iterator.CurrentItem.CityName + " " + iterator.CurrentItem.VisitPlaceName);
            }

            ViewBag.Routes = routes;

            return View();
        }
    }
}
