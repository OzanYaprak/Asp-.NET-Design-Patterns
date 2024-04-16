using DesignPattern.Composite.Components;
using DesignPattern.Composite.Composites;
using DesignPattern.Composite.Data;
using DesignPattern.Composite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Composite.Controllers
{
    public class DefaultController : Controller
    {
        private readonly DBContext _context;

        public DefaultController(DBContext DbContext)
        {
            _context = DbContext;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.Include(x => x.Products).ToList();
            var values = Recursive(categories, new Category { CategoryName = "FirstCategory", CategoryId = 0 }, new ProductComposite(0, "FirstComposite"));

            ViewBag.Values = values;

            return View();
        }

        public ProductComposite Recursive(List<Category> categories, Category firstCategory, ProductComposite firstComposite, ProductComposite leaf = null)
        {
            categories.Where(x => x.UpperCategoryId == firstCategory.CategoryId).ToList().ForEach(x =>
            {
                var productComposite = new ProductComposite(x.CategoryId, x.CategoryName);

                x.Products.ToList().ForEach(x =>
                {
                    productComposite.AddComponent(new ProductComponent(x.ProductId, x.ProductName));
                });

                if (leaf != null) { leaf.AddComponent(productComposite); }
                else { firstComposite.AddComponent(productComposite); }

                Recursive(categories, x, firstComposite, productComposite);
            });
            return firstComposite;
        }
    }
}
