using System;
using System.Collections.Generic;

namespace T5S.Models;

public partial class Estudiante
{
    public int IdEstudiante { get; set; }

    public string? NombreEst { get; set; }

    public string? ApellidoEst { get; set; }

    public DateTime FechaNacimientoEst { get; set; }

    public string? TipoDocumentoEst { get; set; }

    public int NumeroDocumentoEst { get; set; }

    public int CelularEst { get; set; }

    public string? CorreoEst { get; set; }

    public string DireccionEst { get; set; } = null!;

    public string? NombreUsuarioEst { get; set; }

    public string? PasswordEst { get; set; }

    public int IdLogin { get; set; }

    public string? Estado { get; set; }
}
