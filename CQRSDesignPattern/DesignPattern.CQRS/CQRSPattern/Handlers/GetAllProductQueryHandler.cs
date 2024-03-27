using DesignPattern.CQRS.CQRSPattern.Results;
using DesignPattern.CQRS.DAL;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class GetAllProductQueryHandler
    {
        #region Constructor

        private readonly DBContext _context;
        public GetAllProductQueryHandler(DBContext context)
        {
            _context = context;
        }

        #endregion

        public List<GetAllProductQueryResult> Handle()
        {
            var values = _context.Products.Select(x => new GetAllProductQueryResult
            {
                ProductId = x.ProductId,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,

            }).ToList();

            return values;
        }
    }
}