using System;
using System.Collections.Generic;

namespace T5S.Models;

public partial class Login
{
    public int IdLogin { get; set; }

    public string? User { get; set; }

    public string? Password { get; set; }

    public string? Estado { get; set; }

    public int? IdEstudiante { get; set; }
}
