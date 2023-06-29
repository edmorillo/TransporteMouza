using System;
using System.Collections.Generic;

namespace TransporteMouza.Models
{
    public partial class TipoUnidade
    {
        public TipoUnidade()
        {
            Neumaticos = new HashSet<Neumatico>();
        }

        public int IdTipoUnidad { get; set; }
        public string? Detalle { get; set; }
        public string? Chasis { get; set; }

        public virtual ICollection<Neumatico> Neumaticos { get; set; }
    }
}
