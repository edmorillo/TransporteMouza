using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

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
        [Display(Name = "Detalles")]
        public string? Detalle { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de compra")]
        public DateTime? FechaCompra { get; set; }
        [Display(Name = "Forma de Pago")]
        public string? FormaDePago { get; set; }

        public virtual ICollection<Neumatico> Neumaticos { get; set; }
    }
}
