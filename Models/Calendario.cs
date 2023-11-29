using System;
using System.Collections.Generic;

namespace T5S.Models;

public partial class Calendario
{
    public int IdCalendario { get; set; }

    public DateTime FechaCalendario { get; set; }

    public string? DescripcionCalendario { get; set; }

    public string? Estado { get; set; }
}
