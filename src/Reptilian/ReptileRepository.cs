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
            using (var session = _sessionFactory.OpenSession())
            {
                var id = (Guid)session.Save(reptile);
                session.Flush();
                session.Close();
                return id;
            }
        }

        public Reptile GetById(Guid id)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var reptile = session.Get<Reptile>(id);
                return reptile;
            }
        }

        private readonly ISessionFactory _sessionFactory;
    }
}