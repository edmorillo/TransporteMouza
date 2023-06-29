using System;
using System.Collections.Generic;

namespace TransporteMouza.Models
{
    public partial class Viaje
    {
        public int IdViajes { get; set; }
        public string? Origen { get; set; }
        public string? Destino { get; set; }
        public int? IdChoferes { get; set; }
        public int? IdUnidad { get; set; }
        public int? IdCliente { get; set; }
        public decimal? Tarifa { get; set; }
        public string? Detalle { get; set; }
        public int? Remito { get; set; }
        public string? NumContenedor { get; set; }

        public virtual Chofere? IdChoferesNavigation { get; set; }
        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual Unidad? IdUnidadNavigation { get; set; }
    }
}
