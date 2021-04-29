using System;
using System.Collections.Generic;

#nullable disable

namespace CarTallerCDL
{
    public partial class T05Mantenimiento
    {
        public T05Mantenimiento()
        {
            T041MovtoFacturas = new HashSet<T041MovtoFactura>();
        }

        public int F05RowidManto { get; set; }
        public int F05RowidVehiculo { get; set; }
        public int F05RowidTerceroCliente { get; set; }
        public short F05EstadoManto { get; set; }
        public byte[] F05Foto { get; set; }
        public string F05Notas { get; set; }
        public int F05IdMantto { get; set; }
        public decimal? F05VlrMin { get; set; }
        public decimal? F05VlrMax { get; set; }

        public virtual T02Tercero F05RowidTerceroClienteNavigation { get; set; }
        public virtual T03Vehiculo F05RowidVehiculoNavigation { get; set; }
        public virtual ICollection<T041MovtoFactura> T041MovtoFacturas { get; set; }
    }
}
