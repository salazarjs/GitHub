using Ejercicio.ABC.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ejercicio.ABC.Data.Models
{
    public class Usuario : IPersistentModel
    {
        public virtual int UsuarioID { get; set; }

        [StringLength(3, ErrorMessage = "Máximo 3 caracteres")]
        [Required (ErrorMessage = "El campo {0} es requerido")]
        public virtual string Clave { get; set; }

        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public virtual string Nombre { get; set; }

        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public virtual string Apellido { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^(3[01]|[12][0-9]|0[1-9])[-/](1[0-2]|0[1-9])[-/][0-9]{4}$", ErrorMessage = "Fecha invalida (dd/MM/yyyy)")]
        [Required(ErrorMessage = "El campo Fecha de nacimiento es requerido")]
        public virtual DateTime FechaNacimiento { get; set; }

        public virtual bool Estatus { get; set; }

        //public virtual Comentario Comentario { get; set; }
    }
}