using System;
using System.Collections.Generic;

namespace TransporteMouza.Models
{
    public partial class Unidad
    {
        public Unidad()
        {
            Viajes = new HashSet<Viaje>();
        }

        public int IdUnidad { get; set; }
        public string? Matricula { get; set; }
        public int? IdMarca { get; set; }
        public string? Modelo { get; set; }
        public int? AñoUnidad { get; set; }
        public int? CapacidadCarga { get; set; }
        public int? IdChoferes { get; set; }
        public DateTime? FecCompra { get; set; }
        public DateTime? FecMantenimiento { get; set; }
        public int? Kilometros { get; set; }
        public string? EstadoDocumentacion { get; set; }
        public int? IdTipoUnidad { get; set; }

        public virtual ICollection<Viaje> Viajes { get; set; }
    }
}
