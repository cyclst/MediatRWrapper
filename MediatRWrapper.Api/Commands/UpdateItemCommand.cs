using MediatRWrapper.Application.Commands;

namespace MediatRWrapper.Api.Commands
{
    public record UpdateItemCommand : ICommand
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public UpdateItemCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
