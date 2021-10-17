using NUnit.Framework;
using NHibernate;
using Reptilian.DataAccess;

namespace Reptilian.Tests
{
    public class ReptileRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            _sessionFactory = Database.CreateSessionFactory();
        }

        [Test]
        public void SaveRead()
        {
            var repository = new ReptileRepository(_sessionFactory);
            const string reptileName = "Steve";
            const string reptileBreed = "Chameleon";
            var reptile = new Reptile { Name = reptileName, Breed = reptileBreed };
            var reptileId = repository.Save(reptile);
            var retrieved = repository.GetById(reptileId);
            Assert.AreEqual(reptileName, retrieved.Name);
        }

        private ISessionFactory _sessionFactory;
    }
}