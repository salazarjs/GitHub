using System.ComponentModel.DataAnnotations;

namespace Ejercicio.ABC.Data.Models
{
    public class Comentario
    {
        public virtual int ComentarioID { get; set; }

        [StringLength(20, ErrorMessage = "Máximo 50 caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public virtual string Descripcion { get; set; }

        public virtual bool Estatus { get; set; }

        //public virtual Usuario Usuario { get; set; }
    }
}