using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

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

        [Display(Name = "Razón Social")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? RazonSoc { get; set; }
        [Display(Name = "Cuit")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int? Cuitclie { get; set; }
        [Display(Name = "Dirección")]
        public string? DireccionC { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Email { get; set; }
        public int? Telefono { get; set; }
        public string? Localidad { get; set; }
        [Display(Name = "Codigo Postal")]
        public int? CodPostal { get; set; }
        [Display(Name = "IVA")]
        public string? ConIva { get; set; }
        [Display(Name = "Ingresos Brutos")]
        public string? IngresosBrutos { get; set; }

        public virtual ICollection<Viaje> Viajes { get; set; }
    }
}
