using System;
using System.Collections.Generic;

namespace T5S.Models;

public partial class Geografium
{
    public int IdGeografia { get; set; }

    public string Ciudad { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public string? Estado { get; set; }

    public virtual ResevarTutorium? ResevarTutorium { get; set; }
}
