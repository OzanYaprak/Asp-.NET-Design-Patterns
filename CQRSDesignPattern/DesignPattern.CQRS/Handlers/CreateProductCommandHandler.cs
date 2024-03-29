using DesignPattern.CQRS.Commands;
using DesignPattern.CQRS.DAL;
using DesignPattern.CQRS.Models;

namespace DesignPattern.CQRS.Handlers
{
    public class CreateProductCommandHandler
    {
        #region Constructor

        private readonly DBContext _context;
        public CreateProductCommandHandler(DBContext context)
        {
            _context = context;
        }

        #endregion

        public void Handle(CreateProductCommand productCommand)
        {
            _context.Products.Add(new Product
            {
                Name = productCommand.Name,
                Description = productCommand.Description,
                Price = productCommand.Price,
                Status = true,
                Stock = productCommand.Stock,
            });
            _context.SaveChanges();
        }
    }
}
