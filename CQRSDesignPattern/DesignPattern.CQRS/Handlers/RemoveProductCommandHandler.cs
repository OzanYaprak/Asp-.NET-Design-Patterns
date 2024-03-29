using DesignPattern.CQRS.Commands;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.Handlers
{
    public class RemoveProductCommandHandler
    {
        #region Constructor

        private readonly DBContext _context;
        public RemoveProductCommandHandler(DBContext context)
        {
            _context = context;
        }

        #endregion

        public void Handle(RemoveProductCommand command)
        {
            var values = _context.Products.Find(command.Id);
            
            //values.Status = true;

            _context.Remove(values);
            _context.SaveChanges();
        }
    }
}
