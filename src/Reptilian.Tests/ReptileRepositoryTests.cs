using NUnit.Framework;

namespace Reptilian.Tests
{
    public class ReptileRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SaveRead()
        {
            var repository = new ReptileRepository();
            const string reptileName = "Steve";
            const string reptileBreed = "Chameleon";
            var reptile = new Reptile { Name = reptileName, Breed = reptileBreed };
            var reptileId = repository.Save(reptile);
            var retrieved = repository.GetById(reptileId);
            Assert.AreEqual(reptileName, retrieved.Name);
        }
    }
}