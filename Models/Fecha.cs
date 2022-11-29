using System;
using System.Collections.Generic;

namespace ProyectoWEBAdministracionHorarios.Models
{
    public partial class Fecha
    {
        public Fecha()
        {
            TipoDeHorarios = new HashSet<TipoDeHorario>();
        }

        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public virtual ICollection<TipoDeHorario> TipoDeHorarios { get; set; }
    }
}
