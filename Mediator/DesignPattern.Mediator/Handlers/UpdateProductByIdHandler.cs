using DesignPattern.Mediator.Data;
using DesignPattern.Mediator.Queries;
using DesignPattern.Mediator.Results;
using MediatR;

namespace DesignPattern.Mediator.Handlers
{
    public class UpdateProductByIdHandler : IRequestHandler<UpdateProductByIdQuery, UpdateProductByIdResult>
    {
        private readonly Context _context;

        public UpdateProductByIdHandler(Context context)
        {
            _context = context;
        }

        public async Task<UpdateProductByIdResult> Handle(UpdateProductByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Products.FindAsync(request.Id);
            return new UpdateProductByIdResult
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                ProductCategory = values.ProductCategory,
                ProductPrice = values.ProductPrice,
                ProductStock = values.ProductStock,
                ProductStockType = values.ProductStockType,
            };
        }
    }
}
