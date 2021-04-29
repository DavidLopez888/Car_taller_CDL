using System;
using System.Collections.Generic;

#nullable disable

namespace CarTallerCDL
{
    public partial class T041MovtoFactura
    {
        public int F041RowidFactura { get; set; }
        public int F041RowidManto { get; set; }
        public int F041RowidItem { get; set; }
        public int? F041RowidDscto { get; set; }
        public int F041IdItem { get; set; }
        public string F041DescripionItem { get; set; }
        public string F041TipoItem { get; set; }
        public decimal F041VlrBruto { get; set; }
        public decimal F041VlrDesto { get; set; }
        public decimal F041VlrImpto { get; set; }
        public decimal F041VlrNeto { get; set; }
        public string F041Notas { get; set; }
        public int F041RowidMovto { get; set; }
        public decimal F041CantItem { get; set; }

        public virtual T06Descuento F041RowidDsctoNavigation { get; set; }
        public virtual T04Factura F041RowidFacturaNavigation { get; set; }
        public virtual T01Item F041RowidItemNavigation { get; set; }
        public virtual T05Mantenimiento F041RowidMantoNavigation { get; set; }
    }
}
