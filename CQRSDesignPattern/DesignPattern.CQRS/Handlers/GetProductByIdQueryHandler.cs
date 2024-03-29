using DesignPattern.CQRS.Commands;
using DesignPattern.CQRS.DAL;
using DesignPattern.CQRS.Models;
using DesignPattern.CQRS.Queries;
using DesignPattern.CQRS.Results;
using System.Linq;

namespace DesignPattern.CQRS.Handlers
{
    public class GetProductByIdQueryHandler
    {
        #region Constructor

        private readonly DBContext _context;
        public GetProductByIdQueryHandler(DBContext context)
        {
            _context = context;
        }

        #endregion

        public GetProductByIdQueryResult Handle(GetProductByIdQuery queryResult)
        {
            var value = _context.Set<Product>().Find(queryResult.Id);
            return new GetProductByIdQueryResult
            {
                ProductId = value.ProductId,
                Name = value.Name,
                Price = value.Price,
                Stock = value.Stock,
            };
        }
    }
}
