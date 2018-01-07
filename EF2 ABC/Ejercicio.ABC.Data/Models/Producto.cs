using Ejercicio.ABC.Data.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ejercicio.ABC.Data.Models
{
    public class Producto : IPersistentModel
    {
        public virtual int ProductoID { get; set; }

        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public virtual string Descripcion { get; set; }

        public virtual bool Estatus { get; set; }

        public virtual IList<Proveedor> Proveedores { get; set; }
        public Producto()
        {
            Proveedores = new List<Proveedor>();
        }
    }
}