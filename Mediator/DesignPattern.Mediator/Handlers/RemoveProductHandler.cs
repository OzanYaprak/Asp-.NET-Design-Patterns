using DesignPattern.Mediator.Commands;
using DesignPattern.Mediator.Data;
using MediatR;

namespace DesignPattern.Mediator.Handlers
{
    public class RemoveProductHandler : IRequestHandler<RemoveProductCommand>
    {
        private readonly Context _context;
        public RemoveProductHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Products.FindAsync(request.Id);
            _context.Products.Remove(values);
            await _context.SaveChangesAsync();
        }
    }
}
