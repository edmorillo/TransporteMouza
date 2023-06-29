using System;
using System.Collections.Generic;

namespace TransporteMouza.Models
{
    public partial class Neumatico
    {
        public int IdNeumatico { get; set; }
        public string? Marca { get; set; }
        public string? Rodado { get; set; }
        public string? Modelo { get; set; }
        public int? IdTipoUnidad { get; set; }
        public string? Detalle { get; set; }
        public int? IdCompra { get; set; }

        public virtual Compra? IdCompraNavigation { get; set; }
        public virtual TipoUnidade? IdTipoUnidadNavigation { get; set; }
    }
}
