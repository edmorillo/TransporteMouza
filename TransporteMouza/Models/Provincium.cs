using System;
using System.Collections.Generic;

namespace TransporteMouza.Models
{
    public partial class Provincium
    {
        public Provincium()
        {
            Choferes = new HashSet<Chofere>();
        }

        public int IdProvincia { get; set; }
        public string? Provincia { get; set; }

        public virtual ICollection<Chofere> Choferes { get; set; }
    }
}
