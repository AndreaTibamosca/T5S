using System;
using System.Collections.Generic;

namespace T5S.Models;

public partial class Calendario
{
    public int IdCalendario { get; set; }

    public DateTime FechaCalendario { get; set; }

    public string DescripcionCalendario { get; set; } = null!;

    public string? Estado { get; set; }

    public virtual ResevarTutorium? ResevarTutorium { get; set; }

    public virtual Tutor? Tutor { get; set; }
}
