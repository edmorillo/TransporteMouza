using System;
using System.Collections.Generic;

namespace TransporteMouza.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Viajes = new HashSet<Viaje>();
        }

        public int IdCliente { get; set; }
        public string? Nombre { get; set; }
        public string? RazonSoc { get; set; }
        public int? Cuitclie { get; set; }
        public string? DireccionC { get; set; }
        public string? Email { get; set; }
        public int? Telefono { get; set; }
        public string? Localidad { get; set; }
        public int? CodPostal { get; set; }
        public string? ConIva { get; set; }
        public string? IngresosBrutos { get; set; }

        public virtual ICollection<Viaje> Viajes { get; set; }
    }
}
