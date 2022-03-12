using System;
using System.Collections.Generic;

#nullable disable

namespace PARCIAL1A.Models
{
    public partial class CompraElemento
    {
        public int CompraId { get; set; }
        public int? EmpresaId { get; set; }
        public DateTime? FechaCompra { get; set; }
        public int? ElementoId { get; set; }
        public int? Cantidad { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Elemento Elemento { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
