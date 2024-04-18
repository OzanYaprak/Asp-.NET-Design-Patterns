using DesignPattern.Mediator.Commands;
using DesignPattern.Mediator.Data;
using DesignPattern.Mediator.Models;
using MediatR;

namespace DesignPattern.Mediator.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly Context _context;

        public CreateProductHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(new Product
            {
                ProductName = request.ProductName,
                ProductCategory = request.ProductCategory,
                ProductPrice = request.ProductPrice,
                ProductStock = request.ProductStock,
                ProductStockType = request.ProductStockType
            });
            await _context.SaveChangesAsync();
        }
    }
}
