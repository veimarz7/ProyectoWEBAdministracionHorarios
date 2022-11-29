using System;
using System.Collections.Generic;

namespace ProyectoWEBAdministracionHorarios.Models
{
    public partial class TipoDeHorario
    {
        public TipoDeHorario()
        {
            IdEmpleados = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public int? IdHorario { get; set; }
        public int? IdFecha { get; set; }
        /// <summary>
        /// 0 temporal
        /// 1 estatico
        /// </summary>
        public byte Tipo { get; set; }

        public virtual Fecha? IdFechaNavigation { get; set; }
        public virtual Horario? IdHorarioNavigation { get; set; }

        public virtual ICollection<Empleado> IdEmpleados { get; set; }
    }
}
