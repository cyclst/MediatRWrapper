﻿namespace MediatRWrapper.Application.Commands;

public interface ICommandHandler<TCommand> where TCommand : ICommand
{
    Task<bool> Handle(TCommand command, CancellationToken cancellation);
}
