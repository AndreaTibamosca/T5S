using System;
using System.Collections.Generic;

namespace T5S.Models;

public partial class Repositorio
{
    public int IdRepositorio { get; set; }

    public string IdNombreRepositorio { get; set; } = null!;

    public int IdTutor { get; set; }

    public string MediosRepositorio { get; set; } = null!;

    public virtual Tutor IdRepositorioNavigation { get; set; } = null!;
}
