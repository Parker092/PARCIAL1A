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
            Elementos = new HashSet<Elemento>();
            ElementosPorPlatos = new HashSet<ElementosPorPlato>();
            Platos = new HashSet<Plato>();
            PlatosPorCombos = new HashSet<PlatosPorCombo>();
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
        public virtual ICollection<Elemento> Elementos { get; set; }
        public virtual ICollection<ElementosPorPlato> ElementosPorPlatos { get; set; }
        public virtual ICollection<Plato> Platos { get; set; }
        public virtual ICollection<PlatosPorCombo> PlatosPorCombos { get; set; }
    }
}
