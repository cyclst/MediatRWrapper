using MediatRWrapper.Application.Commands;

namespace MediatRWrapper.Api.Commands
{
    public record AddItemCommand : ICommand<Guid>
    {
        public string Name { get; private set; }

        public AddItemCommand(string name)
        {
            Name = name;
        }
    }
}
