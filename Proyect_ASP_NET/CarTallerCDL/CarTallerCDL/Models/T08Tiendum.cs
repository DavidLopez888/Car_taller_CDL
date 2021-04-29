using System;
using System.Collections.Generic;

#nullable disable

namespace CarTallerCDL
{
    public partial class T08Tiendum
    {
        public T08Tiendum()
        {
            T04Facturas = new HashSet<T04Factura>();
            T07Existencis = new HashSet<T07Existenci>();
        }

        public int F08RowidTienda { get; set; }
        public string F08NombreTienda { get; set; }
        public string F08Ciudad { get; set; }

        public virtual ICollection<T04Factura> T04Facturas { get; set; }
        public virtual ICollection<T07Existenci> T07Existencis { get; set; }
    }
}
