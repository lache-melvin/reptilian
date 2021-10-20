using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Reptile> GetReptiles()
        {
            return InTx(session => session.Query<Reptile>().ToList());
        }

        public Reptile GetById(Guid id)
        {
            return InTx(session => session.Get<Reptile>(id));
        }
    }
}