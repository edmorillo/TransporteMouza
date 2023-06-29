using System;
using System.Collections.Generic;

namespace TransporteMouza.Models
{
    public partial class Chofere
    {
        public Chofere()
        {
            Viajes = new HashSet<Viaje>();
        }

        public int IdChoferes { get; set; }
        
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }

        public int? Dni { get; set; }
        
        public string? Email { get; set; }
        public string? Cuil { get; set; }
        public DateTime? FechaNac { get; set; }
        public int? Telefono { get; set; }
        public string? Matricula { get; set; }
        public DateTime? LicenciaVen { get; set; }
        public int? Prov { get; set; }

        public virtual Provincium? ProvNavigation { get; set; }
        public virtual ICollection<Viaje> Viajes { get; set; }
    }
}
