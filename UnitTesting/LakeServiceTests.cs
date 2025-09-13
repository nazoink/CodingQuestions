using NUnit.Framework;
using System;
using System.Linq;
using Project05.Dictionary.Models;
using Project05.Dictionary.Repositories;
using Project05.Dictionary.Services;

namespace UnitTesting
{
    [TestFixture]
    public class LakeServiceTests
        [Test]
        public void Add_NegativeElevation_AllowsLake()
        {
            var repo = new DictionaryLakeRepository();
            var service = new LakeService(repo);
            var lake = new Lake { Name = "BelowSeaLevel", Depth = 10m, WidestPoint = 5m, FarthestLength = 8m, Elevation = -86m, State = "CA" };
            Assert.DoesNotThrow(() => service.AddLake(lake));
            Assert.IsTrue(repo.TryGet("BelowSeaLevel", out var outLake));
            Assert.AreEqual(-86m, outLake.Elevation);
        }
    {
        [Test]
        public void Add_InvalidState_ThrowsValidationException()
        {
            var repo = new DictionaryLakeRepository();
            var service = new LakeService(repo);
            var lake = new Lake { Name = "BadState", Depth = 5m, WidestPoint = 10m, FarthestLength = 20m, Elevation = 100m, State = "XX" };
            Assert.Throws<ArgumentException>(() => service.AddLake(lake));
        }

        [Test]
        public void Add_NegativeNumeric_ThrowsValidationException()
        {
            var repo = new DictionaryLakeRepository();
            var service = new LakeService(repo);
            var lake = new Lake { Name = "Negative", Depth = -1m, WidestPoint = 0m, FarthestLength = 0m, Elevation = 0m, State = "OH" };
            Assert.Throws<ArgumentException>(() => service.AddLake(lake));
        }

        [Test]
        public void SearchByState_ReturnsOnlyMatches()
        {
            var repo = new DictionaryLakeRepository();
            var service = new LakeService(repo);
            service.AddLake(new Lake { Name = "A", Depth = 1m, WidestPoint = 1m, FarthestLength = 1m, Elevation = 1m, State = "CA" });
            service.AddLake(new Lake { Name = "B", Depth = 1m, WidestPoint = 1m, FarthestLength = 1m, Elevation = 1m, State = "NV" });
            var cals = service.SearchByState("CA");
            Assert.AreEqual(1, cals.Count());
            Assert.AreEqual("A", cals.First().Name);
        }
    }
}
