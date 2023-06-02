using MediatR;
using MediatRWrapper.Application.Commands;

namespace MediatRWrapper.Infrastructure.MediatR.Commands
{
    public class MediatRCommandDispatcher : ICommandDispatcher
    {
        private readonly IMediator _mediator;

        public MediatRCommandDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> Dispatch<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand
        {
            return await _mediator.Send(new MediatRRequest<TCommand, bool>(command), cancellationToken);
        }
    }
}