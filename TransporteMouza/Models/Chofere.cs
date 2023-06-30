using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TransporteMouza.Models
{
    public partial class Chofere
    {
        public Chofere()
        {
            Viajes = new HashSet<Viaje>();
        }

        public int IdChoferes { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public int? Dni { get; set; }
        
        public string? Email { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Cuil { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaNac { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int? Telefono { get; set; }
        public string? Matricula { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha VTO Licencia")]
        public DateTime? LicenciaVen { get; set; }

        [Display(Name = "Provincia")]
        public int? Prov { get; set; }
        [Display(Name = "Provincia")]
        public virtual Provincium? ProvNavigation { get; set; }
        public virtual ICollection<Viaje> Viajes { get; set; }
    }
}
