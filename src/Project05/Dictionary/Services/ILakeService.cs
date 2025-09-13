using Project05.Dictionary.Models;

namespace Project05.Dictionary.Services;

public interface ILakeService
{
    void AddLake(Lake lake);
    void UpdateLake(string name, Lake updated);
    Lake GetLake(string name);
    IEnumerable<Lake> SearchByState(string state);
    IEnumerable<Lake> ListAll();
}
