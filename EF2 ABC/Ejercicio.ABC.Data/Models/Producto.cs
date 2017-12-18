using Ejercicio.ABC.Data.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ejercicio.ABC.Data.Models
{
    public class Producto : IPersistentModel
    {
        public virtual int ProductoID { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual bool Estatus { get; set; }
        public virtual IList<Proveedor> Proveedor { get; set; }
        public Producto()
        {
            Proveedor = new List<Proveedor>();
        }
    }
}