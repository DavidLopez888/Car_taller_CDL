using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CarTallerCDL
{
    public partial class T01Item
    {
        public T01Item()
        {
            T041MovtoFacturas = new HashSet<T041MovtoFactura>();
            T06Descuentos = new HashSet<T06Descuento>();
        }

        public int F01RowidItem { get; set; }

        //Id de item
        [Required(ErrorMessage= "El ID del item es obligatorio")]
        public int F01IdItem { get; set; }

        //Descripcion del item
        [Required(ErrorMessage = "La descripcion del item es obligatoria")]
        [StringLength(40)]
        public string F01DescripionItem { get; set; }

        //Tipo de item
        [Required(ErrorMessage = "El tipo de item es obligatorio")]
        [StringLength(10, ErrorMessage = "El tipo de item no puede ser mayor a 10 caracteres")]
        public string F01TipoItem { get; set; }

        //Notas del item
        [StringLength(255, ErrorMessage = "Las notas no puedes ser mayores a 255 caracteres")]
        public string F01Notas { get; set; }

        public virtual T07Existenci T07Existenci { get; set; }
        public virtual ICollection<T041MovtoFactura> T041MovtoFacturas { get; set; }
        public virtual ICollection<T06Descuento> T06Descuentos { get; set; }
    }
}
