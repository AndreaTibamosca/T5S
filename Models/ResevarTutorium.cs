using System;
using System.Collections.Generic;

namespace T5S.Models;

public partial class ResevarTutorium
{
    public int IdReserva { get; set; }

    public DateTime FechaTutoria { get; set; }

    public TimeSpan HoraTutoria { get; set; }

    public int CantidadHoras { get; set; }

    public string? Localidad { get; set; }

    public string? Barrio { get; set; }

    public string? DireccionTutoria { get; set; }

    public string? TipoTutoria { get; set; }

    public string? DescripcionTutoria { get; set; }

    public int? IdTutor { get; set; }

    public int? IdEstudiante { get; set; }

    public int? IdCalendario { get; set; }

    public int IdMateria { get; set; }

    public int IdPago { get; set; }

    public int IdGeografia { get; set; }

    public int? Estado { get; set; }
}
