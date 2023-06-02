using MediatRWrapper.Domain;

namespace MediatRWrapper.Infrastructure.FakeStorage
{
    public interface IItemRepository
    {
        void Save(Item item);
        Item Get(Guid id);

        // It would be much easier to provide a GetItemNames method on this object, but as this project implements CQRS, we dont ;-)
        //IEnumerable<string> GetItemNames();
    }
}
