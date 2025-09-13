using System.Collections.Concurrent;
using System.Threading;
using Project05.Dictionary.Models;

namespace Project05.Dictionary.Repositories;

public class DictionaryLakeRepository : ILakeRepository
{
    private readonly Dictionary<string, Lake> _store = new(StringComparer.OrdinalIgnoreCase);
    private readonly ReaderWriterLockSlim _lock = new();

    public int Count { get { _lock.EnterReadLock(); try { return _store.Count; } finally { _lock.ExitReadLock(); } } }

    public void Add(Lake lake)
    {
        _lock.EnterWriteLock();
        try
        {
            if (_store.ContainsKey(lake.Name))
                throw new ArgumentException($"Lake with name '{lake.Name}' already exists.");
            _store[lake.Name] = lake;
        }
        finally { _lock.ExitWriteLock(); }
    }

    public bool TryAdd(Lake lake)
    {
        _lock.EnterWriteLock();
        try
        {
            if (_store.ContainsKey(lake.Name))
                return false;
            _store[lake.Name] = lake;
            return true;
        }
        finally { _lock.ExitWriteLock(); }
    }

    public bool Remove(string name)
    {
        _lock.EnterWriteLock();
        try { return _store.Remove(name); }
        finally { _lock.ExitWriteLock(); }
    }

    public void Update(string name, Lake updated)
    {
        _lock.EnterWriteLock();
        try
        {
            if (!_store.ContainsKey(name))
                throw new KeyNotFoundException($"Lake '{name}' not found.");
            _store[name] = updated;
        }
        finally { _lock.ExitWriteLock(); }
    }

    public bool TryGet(string name, out Lake lake)
    {
        _lock.EnterReadLock();
        try { return _store.TryGetValue(name, out lake!); }
        finally { _lock.ExitReadLock(); }
    }

    public IEnumerable<Lake> ListAll()
    {
        _lock.EnterReadLock();
        try { return _store.Values.ToList(); }
        finally { _lock.ExitReadLock(); }
    }
}
