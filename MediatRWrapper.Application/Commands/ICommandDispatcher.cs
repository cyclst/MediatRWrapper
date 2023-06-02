namespace MediatRWrapper.Application.Commands;

public interface ICommandDispatcher
{
    public Task<CommandResult> Dispatch(ICommand command, CancellationToken cancellationToken);

    public Task<CommandResult<TResult>> Dispatch<TResult>(ICommand<TResult> command, CancellationToken cancellationToken);
}