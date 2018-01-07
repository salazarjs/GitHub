using Ejercicio.ABC.Data.Models;
using FluentNHibernate.Mapping;

namespace Ejercicio.ABC.Data.Mappings
{
    public class ProductoMap : ClassMap<Producto>
    {
        public ProductoMap()
        {
            Id(p => p.ProductoID);
            Map(p => p.Descripcion).Not.Nullable();
            Map(p => p.Estatus);
            //HasManyToMany(p => p.Proveedores)
            //    .Cascade.All()
            //    .Table("proveedorproducto");
            //Table("producto");
        }
    }
}