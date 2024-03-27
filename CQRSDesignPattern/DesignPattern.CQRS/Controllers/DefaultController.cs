using DesignPattern.CQRS.CQRSPattern.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.CQRS.Controllers
{
    public class DefaultController : Controller
    {
        #region Constructor

        private readonly GetAllProductQueryHandler _getAllProductQueryHandler;

        public DefaultController(GetAllProductQueryHandler getAllProductQueryHandler)
        {
            _getAllProductQueryHandler = getAllProductQueryHandler;
        }

        #endregion

        public IActionResult Index()
        {
            var values = _getAllProductQueryHandler.Handle();

            return View(values);
        }
    }
}
