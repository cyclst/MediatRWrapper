namespace MediatRWrapper.Application.Commands;

public interface ICommandDispatcher
{
    Task<bool> Dispatch<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand;
}