namespace Ejercicio.ABC.Data.Models
{
    public class Comentario
    {
        public virtual int ComentarioID { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual bool Estatus { get; set; }
    }
}