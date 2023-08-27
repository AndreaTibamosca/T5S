using System;
using System.Collections.Generic;

namespace T5S.Models;

public partial class Tutor
{
    public int IdTutor { get; set; }

    public string NombreTutor { get; set; } = null!;

    public string ApellidoTutor { get; set; } = null!;

    public DateTime FechaNacimientoTutor { get; set; }

    public string TipoDocumentoTutor { get; set; } = null!;

    public int NumeroDocumentoTutor { get; set; }

    public int CelularTutor { get; set; }

    public string CorreoTutor { get; set; } = null!;

    public string DireccionTutor { get; set; } = null!;

    public string NombreUsuarioTutor { get; set; } = null!;

    public string PasswordTutor { get; set; } = null!;

    public string ExperienciaTutor { get; set; } = null!;

    public string DocumentosTutor { get; set; } = null!;

    public int IdLogin { get; set; }

    public virtual Login IdTutor1 { get; set; } = null!;

    public virtual TutorMaterium IdTutor2 { get; set; } = null!;

    public virtual Calendario IdTutorNavigation { get; set; } = null!;

    public virtual Repositorio? Repositorio { get; set; }

    public virtual ResevarTutorium? ResevarTutorium { get; set; }
}
