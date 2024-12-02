using MediatR;

namespace ContactsManagementApplication.Interfaces.Queries
{
    public interface IQueries<out TResponse> : IRequest<TResponse> { }
}
