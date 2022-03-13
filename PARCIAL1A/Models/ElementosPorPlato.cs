using System;
using System.Collections.Generic;

#nullable disable

namespace PARCIAL1A.Models
{
    public partial class ElementosPorPlato
    {
        public int ElementoPorPlatoId { get; set; }
        public int? PlatoId { get; set; }
        public int? ElementoId { get; set; }
        public int? Cantidad { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Elemento Elemento { get; set; }
        public virtual Plato Plato { get; set; }
    }
}
