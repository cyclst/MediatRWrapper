using MediatRWrapper.Application.Commands;

namespace MediatRWrapper.Api.Commands
{
    public record AddItemCommand : ICommand
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public AddItemCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
