using DesignPattern.CQRS.Commands;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.Handlers
{
    public class UpdateProductCommandHandler
    {
        #region Constructor

        private readonly DBContext _context;
        public UpdateProductCommandHandler(DBContext context)
        {
            _context = context;
        }

        #endregion

        public void Handle(UpdateProductCommand command)
        {
            var values = _context.Products.Find(command.Id);

            values.Name = command.Name;
            values.Stock = command.Stock;
            values.Price = command.Price;
            values.Description = command.Description;
            values.Status = true;

            _context.SaveChanges();
        }
    }
}
