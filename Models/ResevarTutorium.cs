using System;
using System.Collections.Generic;

namespace T5S.Models;

public partial class ResevarTutorium
{
    public int IdReserva { get; set; }

    public DateTime FechaTutoria { get; set; }

    public TimeSpan HoraTutoria { get; set; }

    public int CantidadHoras { get; set; }

    public string Localidad { get; set; } = null!;

    public string Barrio { get; set; } = null!;

    public string DireccionTutoria { get; set; } = null!;

    public string TipoTutoria { get; set; } = null!;

    public string DescripcionTutoria { get; set; } = null!;

    public int? IdTutor { get; set; }

    public int? IdEstudiante { get; set; }

    public int? IdCalendario { get; set; }

    public int IdMateria { get; set; }

    public int IdPago { get; set; }

    public int IdGeografia { get; set; }

    public virtual Estudiante IdReserva1 { get; set; } = null!;

    public virtual Geografium IdReserva2 { get; set; } = null!;

    public virtual Materium IdReserva3 { get; set; } = null!;

    public virtual FormaPago IdReserva4 { get; set; } = null!;

    public virtual Tutor IdReserva5 { get; set; } = null!;

    public virtual Calendario IdReservaNavigation { get; set; } = null!;
}
