using MediatR;

namespace Publix.Risk.IncidentIntake.Domain.Interfaces
{
    public interface IQuery<T> : IRequest<T> { }
}
