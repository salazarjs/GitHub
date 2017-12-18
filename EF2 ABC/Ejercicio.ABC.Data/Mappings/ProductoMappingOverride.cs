using Ejercicio.ABC.Data.Models;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Ejercicio.ABC.Data.Mappings
{
    public class ProductoMappingOverride : IAutoMappingOverride<Producto>
    {
        public void Override(AutoMapping<Producto> mapping)
        {
            mapping.Id(x => x.ProductoID);
        }
    }
}