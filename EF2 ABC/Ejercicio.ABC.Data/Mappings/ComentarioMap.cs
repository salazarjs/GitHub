using Ejercicio.ABC.Data.Models;
using FluentNHibernate.Mapping;

namespace Ejercicio.ABC.Data.Mappings
{
    public class ComentarioMap : ClassMap<Comentario>
    {
        public ComentarioMap()
        {
            Id(c => c.ComentarioID);
            Map(c => c.Descripcion).Not.Nullable();
            Map(c => c.Estatus).Not.Nullable();
            //References(c => c.Usuario, "UsuarioID").Unique();
            Table("comentario");
        }
    }
}