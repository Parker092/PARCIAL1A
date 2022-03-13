using System;
using System.Collections.Generic;

#nullable disable

namespace PARCIAL1A.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            CompraElementos = new HashSet<CompraElemento>();
        }

        public int EmpresaId { get; set; }
        public string NombreEmpresa { get; set; }
        public string Representante { get; set; }
        public string Nit { get; set; }
        public string Nrc { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<CompraElemento> CompraElementos { get; set; }
    }
}
