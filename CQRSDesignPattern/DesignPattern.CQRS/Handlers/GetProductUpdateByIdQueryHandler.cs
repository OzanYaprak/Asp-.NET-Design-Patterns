using DesignPattern.CQRS.DAL;
using DesignPattern.CQRS.Models;
using DesignPattern.CQRS.Queries;
using DesignPattern.CQRS.Results;

namespace DesignPattern.CQRS.Handlers
{
    public class GetProductUpdateByIdQueryHandler
    {
        #region Constructor

        private readonly DBContext _context;
        public GetProductUpdateByIdQueryHandler(DBContext context)
        {
            _context = context;
        }

        #endregion

        public GetProductUpdateQueryResult Handle(GetProductUpdateByIdQuery getProductUpdateById)
        {
            var value = _context.Products.Find(getProductUpdateById.Id);
            if (value == null) { return null; }

            return new GetProductUpdateQueryResult
            {
                Description = value.Description,
                Name = value.Name,
                Price = value.Price,
                Stock = value.Stock,
                ProductId = value.ProductId,
            };
        }
    }
}
