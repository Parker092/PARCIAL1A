using System;
using System.Collections.Generic;

#nullable disable

namespace PARCIAL1A.Models
{
    public partial class PlatosPorCombo
    {
        public int PlatosPorComboId { get; set; }
        public int? EmpresaId { get; set; }
        public int? ComboId { get; set; }
        public int? PlatoId { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
