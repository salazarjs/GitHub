using Ejercicio.ABC.Data.Models;
using FluentNHibernate.Mapping;

namespace Ejercicio.ABC.Data.Mappings
{
    public class ProveedorMap : ClassMap<Proveedor>
    {
        public ProveedorMap()
        {
            Id(p => p.ProveedorID);
            Map(p => p.RFC).Not.Nullable();
            Map(p => p.Nombre).Not.Nullable();
            Map(p => p.Estatus);
            //HasManyToMany(p => p.Productos)
            //    .Cascade.All()
            //    .Table("proveedorproducto");
            Table("proveedor");
        }
    }
}