using DesignPattern.Mediator.Results;
using MediatR;

namespace DesignPattern.Mediator.Queries
{
    public class GetProductByIdQuery : IRequest<GetProductByIdResult>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
