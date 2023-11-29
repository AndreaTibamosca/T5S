using System;
using System.Collections.Generic;

namespace T5S.Models;

public partial class Tutor
{
    public int IdTutor { get; set; }

    public string? NombreTutor { get; set; }

    public string? ApellidoTutor { get; set; }

    public DateTime FechaNacimientoTutor { get; set; }

    public string? TipoDocumentoTutor { get; set; }

    public int NumeroDocumentoTutor { get; set; }

    public int CelularTutor { get; set; }

    public string? CorreoTutor { get; set; }

    public string? DireccionTutor { get; set; }

    public string? NombreUsuarioTutor { get; set; }

    public string PasswordTutor { get; set; } = null!;

    public string? ExperienciaTutor { get; set; }

    public string? DocumentosTutor { get; set; }

    public int IdLogin { get; set; }

    public string? Estado { get; set; }
}
