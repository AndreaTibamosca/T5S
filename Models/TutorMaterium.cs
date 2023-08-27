using System;
using System.Collections.Generic;

namespace T5S.Models;

public partial class TutorMaterium
{
    public int IdTutorMateria { get; set; }

    public int IdMateria { get; set; }

    public int IdTutor { get; set; }

    public virtual Materium IdTutorMateriaNavigation { get; set; } = null!;

    public virtual Tutor? Tutor { get; set; }
}
