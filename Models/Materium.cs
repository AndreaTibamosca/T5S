using System;
using System.Collections.Generic;

namespace T5S.Models;

public partial class Materium
{
    public int IdMateria { get; set; }

    public string NombreMateria { get; set; } = null!;

    public string CostoMateria { get; set; } = null!;

    public string PruebaMateria { get; set; } = null!;

    public int IdTutorMateria { get; set; }

    public virtual ResevarTutorium? ResevarTutorium { get; set; }

    public virtual TutorMaterium? TutorMaterium { get; set; }
}
