using MediatR;

namespace ContactsManagementApplication.Interfaces.Commands
{
    public interface ICommands<out TResponse> : IRequest<TResponse> { }
}
