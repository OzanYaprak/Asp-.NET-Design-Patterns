using DesignPattern.Mediator.Commands;
using DesignPattern.Mediator.Data;
using MediatR;

namespace DesignPattern.Mediator.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly Context _context;

        public UpdateProductHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Products.FindAsync(request.ProductId);
            
            values.ProductName = request.ProductName;
            values.ProductPrice = request.ProductPrice;
            values.ProductStock = request.ProductStock;
            values.ProductCategory = request.ProductCategory;
            values.ProductStockType = request.ProductStockType;

            await _context.SaveChangesAsync();
        }
    }
}
