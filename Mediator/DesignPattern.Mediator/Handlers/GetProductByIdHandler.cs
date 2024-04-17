using DesignPattern.Mediator.Data;
using DesignPattern.Mediator.Queries;
using DesignPattern.Mediator.Results;
using MediatR;

namespace DesignPattern.Mediator.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        private readonly Context _context;

        public GetProductByIdHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Products.FindAsync(request.Id);

            return new GetProductByIdResult
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                ProductStock = values.ProductStock,
            };
        }
    }
}
