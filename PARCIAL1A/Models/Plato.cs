using System;
using System.Collections.Generic;

#nullable disable

namespace PARCIAL1A.Models
{
    public partial class Plato
    {
        public Plato()
        {
            ElementosPorPlatos = new HashSet<ElementosPorPlato>();
            PlatosPorCombos = new HashSet<PlatosPorCombo>();
        }

        public int PlatoId { get; set; }
        public int? EmpresaId { get; set; }
        public string NombrePlato { get; set; }
        public string DescripcionPlato { get; set; }
        public string Precio { get; set; }
        public string TiempoPreparacion { get; set; }
        public string Imagen { get; set; }
        public string AplicaPropina { get; set; }
        public string Lunes { get; set; }
        public string Martes { get; set; }
        public string Miercoles { get; set; }
        public string Jueves { get; set; }
        public string Viernes { get; set; }
        public string Sabado { get; set; }
        public string Domingo { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<ElementosPorPlato> ElementosPorPlatos { get; set; }
        public virtual ICollection<PlatosPorCombo> PlatosPorCombos { get; set; }
    }
}
