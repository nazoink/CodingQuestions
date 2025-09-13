using Project05.Dictionary.Models;

namespace Project05.Dictionary.Repositories;

public interface ILakeRepository
{
    void Add(Lake lake);
    bool TryAdd(Lake lake);
    bool Remove(string name);
    void Update(string name, Lake updated);
    bool TryGet(string name, out Lake lake);
    IEnumerable<Lake> ListAll();
    int Count { get; }
}
