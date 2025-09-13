using NUnit.Framework;
using System;
using System.Linq;
using Project05.Dictionary.Models;
using Project05.Dictionary.Repositories;

namespace UnitTesting
{
    [TestFixture]
    public class LakeRepositoryTests
    {
        [Test]
        public void Add_NewLake_IncreasesCount()
        {
            var repo = new DictionaryLakeRepository();
            var lake = new Lake { Name = "TestLake", Depth = 10m, WidestPoint = 100m, FarthestLength = 200m, Elevation = 500m, State = "CA" };
            repo.Add(lake);
            Assert.AreEqual(1, repo.Count);
            Assert.IsTrue(repo.TryGet("TestLake", out var outLake));
            Assert.AreEqual("TestLake", outLake.Name);
        }

        [Test]
        public void Add_Duplicate_Throws()
        {
            var repo = new DictionaryLakeRepository();
            var lake = new Lake { Name = "DupLake", Depth = 1m, WidestPoint = 1m, FarthestLength = 1m, Elevation = 1m, State = "TX" };
            repo.Add(lake);
            Assert.Throws<ArgumentException>(() => repo.Add(lake));
        }

        [Test]
        public void Keys_AreCaseInsensitive()
        {
            var repo = new DictionaryLakeRepository();
            var lake = new Lake { Name = "CaseLake", Depth = 2m, WidestPoint = 2m, FarthestLength = 2m, Elevation = 2m, State = "NY" };
            repo.Add(lake);
            Assert.IsTrue(repo.TryGet("caselake", out var _));
            Assert.IsTrue(repo.TryGet("CASELAKE", out var _));
        }
    }
}
