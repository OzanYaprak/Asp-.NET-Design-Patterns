using DesignPattern.Mediator.Results;
using MediatR;

namespace DesignPattern.Mediator.Queries
{
    public class UpdateProductByIdQuery : IRequest<UpdateProductByIdResult>
    {
        public int Id { get; set; }

        public UpdateProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
