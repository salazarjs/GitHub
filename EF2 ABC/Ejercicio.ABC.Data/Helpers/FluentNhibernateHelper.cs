using Ejercicio.ABC.Data.Configurations;
using Ejercicio.ABC.Data.Models;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Ejercicio.ABC.Data.Helpers
{
    public static class FluentNhibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(GetSqlConfiguration("DefaultConnection"))
                .Mappings(m => m.AutoMappings
                .Add(AutoMap.AssemblyOf<Usuario>(new AutomappingConfiguration())
                .IncludeBase<Proveedor>()
                .Override<Proveedor>(map => map
                .HasManyToMany(e => e.Producto)
                .Inverse().Cascade.SaveUpdate().Table("ProveedorProducto")
                .ParentKeyColumn("ProveedorID").ChildKeyColumn("ProductoID"))
                .UseOverridesFromAssemblyOf<AutomappingConfiguration>()))
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                .Create(false, false))
                .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }

        private static MsSqlConfiguration GetSqlConfiguration(string databaseConnectionStringKey)
        {
            return MsSqlConfiguration.MsSql2012
                .ConnectionString(c => c.FromConnectionStringWithKey(databaseConnectionStringKey));
        }
    }
}