using System;
using NHibernate;

namespace Reptilian
{
    public abstract class BaseRepository
    {

        protected BaseRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        protected T InTx<T>(Func<ISession, T> function)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    T result;
                    try
                    {
                        result = function.Invoke(session);
                        tx.Commit();
                        return result;
                    }
#pragma warning disable CS0168 // variable declared but never used
                    catch (Exception ex)
                    {
                        // TODO: include retry logic in exception handling
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        private readonly ISessionFactory _sessionFactory;
    }
}