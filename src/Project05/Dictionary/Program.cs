using Project05.Dictionary.Models;
using Project05.Dictionary.Repositories;
using Project05.Dictionary.Services;

var repo = new DictionaryLakeRepository();
var service = new LakeService(repo);

// Seed demo lakes
service.AddLake(new Lake { Name = "Tahoe", Depth = 501m, WidestPoint = 19.3m, FarthestLength = 35.1m, Elevation = 1897m, State = "CA" });
service.AddLake(new Lake { Name = "Superior", Depth = 406m, WidestPoint = 257m, FarthestLength = 563m, Elevation = 183m, State = "MI" });
service.AddLake(new Lake { Name = "Okeechobee", Depth = 3.7m, WidestPoint = 48m, FarthestLength = 64m, Elevation = 5m, State = "FL" });
service.AddLake(new Lake { Name = "Crater", Depth = 594m, WidestPoint = 8m, FarthestLength = 9.7m, Elevation = 1883m, State = "OR" });
service.AddLake(new Lake { Name = "Great Salt Lake", Depth = 10m, WidestPoint = 80m, FarthestLength = 120m, Elevation = 1280m, State = "UT" });
service.AddLake(new Lake { Name = "Salton Sea", Depth = 13m, WidestPoint = 24m, FarthestLength = 56000m, Elevation = -86m, State = "CA" });

Console.WriteLine("All lakes:");
foreach (var lake in service.ListAll())
	Console.WriteLine($"- {lake.Name} ({lake.State}): Depth={lake.Depth}m, Width={lake.WidestPoint}km, Length={lake.FarthestLength}km, Elev={lake.Elevation}m");

Console.WriteLine("\nGet by name: Tahoe");
var tahoe = service.GetLake("tahoe");
Console.WriteLine($"Tahoe: Depth={tahoe.Depth}m, State={tahoe.State}");

Console.WriteLine("\nUpdate Okeechobee's depth to 4.2m");
var okeechobee = service.GetLake("Okeechobee");
okeechobee.Depth = 4.2m;
service.UpdateLake("Okeechobee", okeechobee);
Console.WriteLine($"Okeechobee new depth: {service.GetLake("Okeechobee").Depth}m");

Console.WriteLine("\nRemove Superior");
repo.Remove("Superior");
Console.WriteLine("Lakes after removal:");
foreach (var lake in service.ListAll())
	Console.WriteLine($"- {lake.Name}");
