using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CarTallerCDL
{
    public partial class T04Factura
    {
        public T04Factura()
        {
            T041MovtoFacturas = new HashSet<T041MovtoFactura>();
        }

        public int F04RowidFactura { get; set; }

        //Consec Factura
        [Required(ErrorMessage = "El consecutivo del tercero es obligatorio")]
        public int F04ConsecDocto { get; set; }

        //Tercero
        [Required(ErrorMessage = "El ID del tercero es obligatorio")]
        public int F04RowidTerceroCliente { get; set; }
        public int F04RowidTerceroMecanico { get; set; }
        public string F04RazonSocialCliente { get; set; }
        public string F04RazonSocialMecanico { get; set; }
        public string F04Notas { get; set; }
        public DateTime F04FechaDocto { get; set; }
        public decimal F04VlrBruto { get; set; }
        public decimal F04VlrDesto { get; set; }
        public decimal F04VlrImpto { get; set; }
        public decimal F04VlrNeto { get; set; }
        public int? F04RowidTienda { get; set; }

        public virtual T02Tercero F04RowidTerceroClienteNavigation { get; set; }
        public virtual T02Tercero F04RowidTerceroMecanicoNavigation { get; set; }
        public virtual T08Tiendum F04RowidTiendaNavigation { get; set; }
        public virtual ICollection<T041MovtoFactura> T041MovtoFacturas { get; set; }
    }
}
