using MediatR;
using MediatRWrapper.Application.Commands;

namespace MediatRWrapper.Infrastructure.MediatR.Commands
{
    public class MediatRCommandHandler<TCommand> : IRequestHandler<MediatRRequest<TCommand, bool>, bool>
        where TCommand : ICommand
    {
        private readonly List<ICommandHandler<TCommand>> _handlers;

        public MediatRCommandHandler(IEnumerable<ICommandHandler<TCommand>> handlers)
        {
            _handlers = handlers.ToList() ?? throw new ArgumentNullException(nameof(handlers));

            if (_handlers.Count > 1)
                throw new ApplicationException("More than one command handler registered");
        }

        public async Task<bool> Handle(MediatRRequest<TCommand, bool> request, CancellationToken cancellationToken)
        {
            var handler = _handlers.First();

            return await handler.Handle(request.Request, cancellationToken);
        }
    }
}