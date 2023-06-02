﻿using MediatRWrapper.Domain;

namespace MediatRWrapper.Infrastructure.InMemoryStorage
{
    public class ItemRepository : IItemRepository
    {
        private readonly FakeStore<Item> _store;

        public ItemRepository(FakeStore<Item> store)
        {
            _store = store;
        }

        public Item Get(Guid id)
        {
            return _store.Get(id);
        }

        public void Save(Item item)
        {
            _store.Save(item.Id, item);
        }
    }
}
