using Ejercicio.ABC.Data.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ejercicio.ABC.Data.Models
{
    public class Proveedor : IPersistentModel
    {
        public virtual int ProveedorID { get; set; }

        [StringLength(13, ErrorMessage = "Máximo 3 caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public virtual string RFC { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public virtual string Nombre { get; set; }

        public virtual bool Estatus { get; set; }

        public virtual IList<Producto> Producto { get; set; }

        public Proveedor()
        {
            Producto = new List<Producto>();
        }
    }
}