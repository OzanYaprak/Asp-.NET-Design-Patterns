using DesignPattern.CQRS.Commands;
using DesignPattern.CQRS.Handlers;
using DesignPattern.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.CQRS.Controllers
{
    public class DefaultController : Controller
    {
        #region Constructor

        private readonly GetAllProductQueryHandler _getAllProductQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;

        public DefaultController(GetAllProductQueryHandler getAllProductQueryHandler, CreateProductCommandHandler createProductCommandHandler, GetProductByIdQueryHandler productByIdQueryHandler, RemoveProductCommandHandler removeProductCommandHandler)
        {
            _getAllProductQueryHandler = getAllProductQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _getProductByIdQueryHandler = productByIdQueryHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
        }

        #endregion

        public IActionResult Index()
        {
            var values = _getAllProductQueryHandler.Handle();

            return View(values);
        }
        
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(CreateProductCommand command)
        {
            _createProductCommandHandler.Handle(command);
            return RedirectToAction("Index","Default");
        }

        public IActionResult GetProduct(int id)
        {
            var values = _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
            return View(values);
        }

        public IActionResult DeleteProduct(int id)
        {
            _removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction("Index", "Default");
        }
    }
}
