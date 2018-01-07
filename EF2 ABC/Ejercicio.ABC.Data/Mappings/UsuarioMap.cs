using Ejercicio.ABC.Data.Models;
using FluentNHibernate.Mapping;

namespace Ejercicio.ABC.Data.Mappings
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Id(u => u.UsuarioID);
            Map(u => u.Clave).Unique().Not.Nullable();
            Map(u => u.Nombre).Not.Nullable();
            Map(u => u.Apellido).Not.Nullable();
            Map(u => u.FechaNacimiento).Not.Nullable();
            Map(u => u.Estatus);
            //HasOne(u => u.Comentario).PropertyRef(x => x.Usuario);
            Table("usuario");
        }
    }
}