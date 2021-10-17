using System;
using NHibernate;

namespace Reptilian
{
    public class ReptileRepository
    {
        public ReptileRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public Guid Save(Reptile reptile)
        {
            _reptile = reptile;
            _reptile.Id = Guid.NewGuid();
            return _reptile.Id;
        }

        public Reptile GetById(Guid id)
        {
            return _reptile;
        }

        private Reptile _reptile;
        private readonly ISessionFactory _sessionFactory;
    }
}