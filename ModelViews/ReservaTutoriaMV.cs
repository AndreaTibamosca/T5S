using Microsoft.VisualBasic;

namespace T5S.ModelsView
{
    public class ReservaTutoriaMV
    {
        public int Id { get; set; }

        public DateTime FechaTutoria { get; set; }

        public TimeSpan HoraTutoria { get; set; }

        public int CantidadHoras { get; set; }

        public string? Localidad { get; set; }

        public string? Barrio { get; set; }

        public string? DireccionTutoria { get; set; }

        public string? TipoTutoria { get; set; }

        public string? DescripcionTutoria { get; set; }

        public int? Estado { get; set; }
    }
}
