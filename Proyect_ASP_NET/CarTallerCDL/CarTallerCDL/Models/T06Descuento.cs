using System;
using System.Collections.Generic;

#nullable disable

namespace CarTallerCDL
{
    public partial class T06Descuento
    {
        public T06Descuento()
        {
            T041MovtoFacturas = new HashSet<T041MovtoFactura>();
        }

        public int F06RowidDescto { get; set; }
        public int? F06RowidItem { get; set; }
        public int? F06RowidTerceroCliente { get; set; }
        public short F06Estado { get; set; }
        public decimal? F06VlrMin { get; set; }
        public decimal? F06VlrMax { get; set; }

        public virtual T01Item F06RowidItemNavigation { get; set; }
        public virtual T02Tercero F06RowidTerceroClienteNavigation { get; set; }
        public virtual ICollection<T041MovtoFactura> T041MovtoFacturas { get; set; }
    }
}
