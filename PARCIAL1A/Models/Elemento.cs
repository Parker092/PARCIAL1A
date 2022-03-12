using System;
using System.Collections.Generic;

#nullable disable

namespace PARCIAL1A.Models
{
    public partial class Elemento
    {
        public int ElementoId { get; set; }
        public int? EmpresaId { get; set; }
        public string Elemento1 { get; set; }
        public int? CantidadMinima { get; set; }
        public string UnidadMedida { get; set; }
        public float? Costo { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? Inventario { get; set; }
    }
}
