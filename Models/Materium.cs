using System;
using System.Collections.Generic;

namespace T5S.Models;

public partial class Materium
{
    public int IdMateria { get; set; }

    public string? NombreMateria { get; set; }

    public string? CostoMateria { get; set; }

    public string? PruebaMateria { get; set; }

    public int IdTutorMateria { get; set; }

    public string? Estado { get; set; }
}
