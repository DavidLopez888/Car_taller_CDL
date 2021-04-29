using System;
using System.Collections.Generic;

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
        public int F01IdItem { get; set; }
        public string F01DescripionItem { get; set; }
        public string F01TipoItem { get; set; }
        public string F01Notas { get; set; }

        public virtual T07Existenci T07Existenci { get; set; }
        public virtual ICollection<T041MovtoFactura> T041MovtoFacturas { get; set; }
        public virtual ICollection<T06Descuento> T06Descuentos { get; set; }
    }
}
