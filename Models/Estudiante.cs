using System;
using System.Collections.Generic;

namespace T5S.Models;

public partial class Estudiante
{
    public int IdEstudiante { get; set; }

    public string NombreEst { get; set; } = null!;

    public string ApellidoEst { get; set; } = null!;

    public DateTime FechaNacimientoEst { get; set; }

    public string TipoDocumentoEst { get; set; } = null!;

    public int NumeroDocumentoEst { get; set; }

    public int CelularEst { get; set; }

    public string CorreoEst { get; set; } = null!;

    public string DireccionEst { get; set; } = null!;

    public string NombreUsuarioEst { get; set; } = null!;

    public string PasswordEst { get; set; } = null!;

    public int IdLogin { get; set; }

    public virtual Login? Login { get; set; }

    public virtual ResevarTutorium? ResevarTutorium { get; set; }
}
