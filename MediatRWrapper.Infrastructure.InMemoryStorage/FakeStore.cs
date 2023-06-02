namespace MediatRWrapper.Infrastructure.InMemoryStorage
{
    public class FakeStore<TItem>
    {
        private IDictionary<Guid, TItem> _dictionary;

        public FakeStore()
        {
            _dictionary = new Dictionary<Guid, TItem>();
        }

        public dynamic Get(Guid id)
        {
            return _dictionary[id];
        }

        public void Save(Guid id, TItem item)
        {
            if(_dictionary.ContainsKey(id))
                _dictionary[id] = item;
            else
                _dictionary.Add(id, item);
        }

        public IEnumerable<TItem> GetAll()
        {
            return _dictionary.Values;
        }
    }
}