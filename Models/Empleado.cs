using System;
using System.Collections.Generic;

namespace ProyectoWEBAdministracionHorarios.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            IdTipoDeHorarios = new HashSet<TipoDeHorario>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<TipoDeHorario> IdTipoDeHorarios { get; set; }
    }
}
