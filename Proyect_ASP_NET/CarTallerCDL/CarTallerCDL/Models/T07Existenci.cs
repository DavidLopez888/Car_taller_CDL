using System;
using System.Collections.Generic;

#nullable disable

namespace CarTallerCDL
{
    public partial class T07Existenci
    {
        public int F07RowidItem { get; set; }
        public decimal F07CantExistencia { get; set; }
        public int? F07RowidTienda { get; set; }

        public virtual T01Item F07RowidItemNavigation { get; set; }
        public virtual T08Tiendum F07RowidTiendaNavigation { get; set; }
    }
}
