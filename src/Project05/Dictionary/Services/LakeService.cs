using Project05.Dictionary.Models;
using Project05.Dictionary.Repositories;

namespace Project05.Dictionary.Services;

public class LakeService : ILakeService
{
    private static readonly HashSet<string> AllowedStates = new(StringComparer.OrdinalIgnoreCase)
    {
        "AL","AK","AZ","AR","CA","CO","CT","DE","FL","GA","HI","ID","IL","IN","IA","KS","KY","LA","ME","MD","MA","MI","MN","MS","MO","MT","NE","NV","NH","NJ","NM","NY","NC","ND","OH","OK","OR","PA","RI","SC","SD","TN","TX","UT","VT","VA","WA","WV","WI","WY","DC"
    };
    private readonly ILakeRepository _repo;

    public LakeService(ILakeRepository repo)
    {
        _repo = repo;
    }

    public void AddLake(Lake lake)
    {
        lake.Validate();
        if (!AllowedStates.Contains(lake.State))
            throw new ArgumentException($"State '{lake.State}' is not a valid US state or DC.");
        _repo.Add(lake);
    }

    public void UpdateLake(string name, Lake updated)
    {
        updated.Validate();
        if (!AllowedStates.Contains(updated.State))
            throw new ArgumentException($"State '{updated.State}' is not a valid US state or DC.");
        _repo.Update(name, updated);
    }

    public Lake GetLake(string name)
    {
        if (!_repo.TryGet(name, out var lake))
            throw new KeyNotFoundException($"Lake '{name}' not found.");
        return lake;
    }

    public IEnumerable<Lake> SearchByState(string state)
    {
        return _repo.ListAll().Where(l => l.State.Equals(state, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Lake> ListAll() => _repo.ListAll();
}
