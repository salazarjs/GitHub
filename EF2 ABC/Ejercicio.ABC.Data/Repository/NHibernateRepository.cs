using Ejercicio.ABC.Data.Repository;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System.Collections.Generic;
using System.Configuration;

namespace Ejercicio.ABC.Data.Helpers
{
    public class NHibernateRepository<T> : IRepository<T> where T : class
    {
        public static ISession OpenSession(string ConnectionStringKey)
        {
            IPersistenceConfigurer dbConnection = null;

            if (ConfigurationManager.ConnectionStrings[ConnectionStringKey] != null)
            {
                switch (ConfigurationManager.ConnectionStrings[ConnectionStringKey].ProviderName.ToLower())
                {
                    case "system.data.sqlclient":
                        dbConnection = MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey(ConnectionStringKey));
                        break;
                    case "npgsql":
                        dbConnection = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(c => c.FromConnectionStringWithKey(ConnectionStringKey));
                        break;
                }
            }

            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(dbConnection)
                 .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateRepository<T>>())
                .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }

        public void Delete(T value)
        {
            using (var sessioned = OpenSession("DefaultConnection"))
            {
                using (var transaction = sessioned.BeginTransaction())
                {
                    sessioned.Delete(value);
                    transaction.Commit();
                }
            }
        }

        public T Get(object id)
        {
            using (var session = OpenSession("DefaultConnection"))
            {
                using (var transaction = session.BeginTransaction())
                {
                    T returnVal = session.Get<T>(id);
                    transaction.Commit();
                    return returnVal;
                }
            }
        }

        public IList<T> GetAll()
        {
            using (var sessioned = OpenSession("DefaultConnection"))
            {
                using (var transaction = sessioned.BeginTransaction())
                {
                    IList<T> returnVal = sessioned.CreateCriteria<T>().List<T>();
                    transaction.Commit();
                    return returnVal;
                }
            }
        }

        public void Save(T value)
        {
            using (var sessioned = OpenSession("DefaultConnection"))
            {
                using (var transaction = sessioned.BeginTransaction())
                {
                    sessioned.Save(value);
                    transaction.Commit();
                }
            }
        }

        public void Update(T value)
        {
            using (var sessioned = OpenSession("DefaultConnection"))
            {
                using (var transaction = sessioned.BeginTransaction())
                {
                    sessioned.Update(value);
                    transaction.Commit();
                }
            }
        }
    }
}