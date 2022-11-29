using System;
using System.Collections.Generic;

namespace ProyectoWEBAdministracionHorarios.Models
{
    public partial class Horario
    {
        public Horario()
        {
            TipoDeHorarios = new HashSet<TipoDeHorario>();
        }

        public int Id { get; set; }
        public string HoraInicio { get; set; } = null!;
        public string HoraFin { get; set; } = null!;
        /// <summary>
        /// 0 INACTIVO
        /// 1 ACTIVO
        /// </summary>
        public string? Lunes { get; set; }
        public string? Martes { get; set; }
        public string? Miercoles { get; set; }
        public string? Jueves { get; set; }
        public string? Viernes { get; set; }
        public string? Sabado { get; set; }
        public string? Domingo { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<TipoDeHorario> TipoDeHorarios { get; set; }
    }
}
