using DesignPattern.TemplateMethod.Models;
using DesignPattern.TemplateMethod.Plans;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.TemplateMethod.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult BasicPlanIndex()
        {
            NetflixPlans netflixPlans = new BasicPlan();
            netflixPlans.CreatePlan(); //Eğer bu methodu çağırırsak, aşağıdaki ViewBag kısımlarını ve View kısmında gerekli ViewBag alanlarını kapatmamız gerekiyor !

            //ViewBag.planType = netflixPlans.PlanType("Temel Plan");
            //ViewBag.personCount = netflixPlans.PersonCount(1);
            //ViewBag.price = netflixPlans.Price(65.99);
            //ViewBag.content = netflixPlans.Content("Film-Dizi");
            //ViewBag.resolution = netflixPlans.Resolution("480px");

            return View(netflixPlans);
        }

        public IActionResult StandartPlanIndex()
        {
            NetflixPlans netflixPlans = new StandartPlan();
            
            netflixPlans.CreatePlan(); 

            return View(netflixPlans);
        }

        public IActionResult UltraPlanIndex()
        {
            NetflixPlans netflixPlans = new UltraPlan();

            netflixPlans.CreatePlan();

            return View(netflixPlans);
        }
    }
}
