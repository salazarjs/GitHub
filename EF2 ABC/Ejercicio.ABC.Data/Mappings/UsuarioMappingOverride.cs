using Ejercicio.ABC.Data.Models;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Ejercicio.ABC.Data.Mappings
{
    public class UsuarioMappingOverride : IAutoMappingOverride<Usuario>
    {
        public void Override(AutoMapping<Usuario> mapping)
        {
            mapping.Id(x => x.UsuarioID);
        }
    }
}