using Microsoft.VisualBasic;

namespace T5S.ModelsView
{
    public class ReservaTutoriaMV
    {
        public int Id { get; set; }

        public DateTime FechaTutoria { get; set; }

        public TimeSpan HoraTutoria { get; set; }

        public int CantidadHoras { get; set; }

        public string Localidad { get; set; } = null!;

        public string Barrio { get; set; } = null!;

        public string DireccionTutoria { get; set; } = null!;

        public string TipoTutoria { get; set; } = null!;

        public string DescripcionTutoria { get; set; } = null!;

        public string NombreTutor { get; set; } = null!;

        public string NombreEstudiante { get; set; } = null!;

        public DateTime Fecha { get; set; }

        public string NombreMateria { get; set; } = null!;

        public int ValoraPagar { get; set; }

        public string Ciudad { get; set; } = null!;
    }
}
