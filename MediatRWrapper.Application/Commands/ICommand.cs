using MediatR;

namespace MediatRWrapper.Application.Commands
{
    public interface ICommand : IRequest<CommandResult>
    {
    }

    public interface ICommand<T> : IRequest<CommandResult<T>>
    {
    }
}
