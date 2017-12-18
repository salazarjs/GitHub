using Ejercicio.ABC.Data.Models;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Ejercicio.ABC.Data.Mappings
{
    public class ProveedorMappingOverride : IAutoMappingOverride<Proveedor>
    {
        public void Override(AutoMapping<Proveedor> mapping)
        {
            mapping.Id(x => x.ProveedorID);
        }
    }
}