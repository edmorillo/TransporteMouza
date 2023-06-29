using System;
using System.Collections.Generic;

namespace TransporteMouza.Models
{
    public partial class Compra
    {
        public Compra()
        {
            Neumaticos = new HashSet<Neumatico>();
        }

        public int IdCompra { get; set; }
        public string? Neumatico { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public string? Detalle { get; set; }
        public DateTime? FechaCompra { get; set; }
        public string? FormaDePago { get; set; }

        public virtual ICollection<Neumatico> Neumaticos { get; set; }
    }
}
