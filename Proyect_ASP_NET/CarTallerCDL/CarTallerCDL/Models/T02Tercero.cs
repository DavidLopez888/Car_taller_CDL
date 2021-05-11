using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CarTallerCDL
{
    public partial class T02Tercero
    {
        public T02Tercero()
        {
            T03Vehiculos = new HashSet<T03Vehiculo>();
            T04FacturaF04RowidTerceroClienteNavigations = new HashSet<T04Factura>();
            T04FacturaF04RowidTerceroMecanicoNavigations = new HashSet<T04Factura>();
            T05Mantenimientos = new HashSet<T05Mantenimiento>();
            T06Descuentos = new HashSet<T06Descuento>();
        }

        public int F02RowidTercero { get; set; }

        //Id Tercero
        [Required(ErrorMessage="El id del tercero es obligatorio")]
        public string F02IdDocumento { get; set; }
        //NIT
        [Required(ErrorMessage = "El NIT del tercero es obligatorio")]
        public string F02Nit { get; set; }
        //Razon social
        [Required(ErrorMessage = "La razon social es obligatoria")]
        public string F02RazonSocial { get; set; }
        public string F02Nombre1 { get; set; }
        public string F02Nombre2 { get; set; }
        public string F02Apellido1 { get; set; }
        public string F02Apellido2 { get; set; }
        //Tipo Docto
        [Required(ErrorMessage = "El Tipo de documento es obligatorio")]
        public string F02TipoDocto { get; set; }
        public short? F02IndCliente { get; set; }
        public short? F02IndEmpleado { get; set; }
        public int? F02Telfeono { get; set; }
        public string F02Direccion { get; set; }
        public string F02Email { get; set; }
        public short F02Estado { get; set; }
        public decimal? F02VlrPresupuesto { get; set; }
        public string F02Notas { get; set; }

        public virtual ICollection<T03Vehiculo> T03Vehiculos { get; set; }
        public virtual ICollection<T04Factura> T04FacturaF04RowidTerceroClienteNavigations { get; set; }
        public virtual ICollection<T04Factura> T04FacturaF04RowidTerceroMecanicoNavigations { get; set; }
        public virtual ICollection<T05Mantenimiento> T05Mantenimientos { get; set; }
        public virtual ICollection<T06Descuento> T06Descuentos { get; set; }
    }
}
