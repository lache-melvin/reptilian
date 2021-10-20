using System.Collections.Generic;
using Reptilian.DataAccess;

namespace Reptilian
{
    class ReptileService
    {
        public List<Reptile> GetReptiles()
        {
            var _sessionFactory = Database.CreateSessionFactory();

            var repository = new ReptileRepository(_sessionFactory);
            var reptiles = repository.GetReptiles();
            return reptiles;
        }
    }
}
