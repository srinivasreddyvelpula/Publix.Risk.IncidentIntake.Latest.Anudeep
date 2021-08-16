using MediatR;

namespace Publix.Risk.IncidentIntake.Domain.Interfaces
{
    public interface IQueryHandler<TRequest, TResponse> :
        IRequestHandler<TRequest, TResponse>
        where TRequest : IQuery<TResponse>
    {
    }
}
