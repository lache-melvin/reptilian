using System;
using NHibernate;

namespace Reptilian
{
    public class ReptileRepository : BaseRepository
    {
        public ReptileRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        public Guid Save(Reptile reptile)
        {
            return InTx(session => (Guid)session.Save(reptile));
        }

        public Reptile GetById(Guid id)
        {
            return InTx(session => session.Get<Reptile>(id));
        }
    }
}