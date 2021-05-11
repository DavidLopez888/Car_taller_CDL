using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CarTallerCDL
{
    public partial class T03Vehiculo
    {
        public T03Vehiculo()
        {
            T05Mantenimientos = new HashSet<T05Mantenimiento>();
        }

        public int F03RowidVehivulo { get; set; }
        public int F03RowidTercero { get; set; }

        //Placa
        [Required(ErrorMessage = "La placa es obligatoria")]
        public string F03Placa { get; set; }
        public string F03Descripcion { get; set; }
        public string F03Notas { get; set; }

        public virtual T02Tercero F03RowidTerceroNavigation { get; set; }
        public virtual ICollection<T05Mantenimiento> T05Mantenimientos { get; set; }
    }
}
