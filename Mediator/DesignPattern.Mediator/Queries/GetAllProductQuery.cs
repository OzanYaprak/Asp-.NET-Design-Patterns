using DesignPattern.Mediator.Results;
using MediatR;

namespace DesignPattern.Mediator.Queries
{
    public class GetAllProductQuery : IRequest<List<GetAllProductResult>>
    {
    }
}
