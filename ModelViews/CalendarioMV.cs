namespace T5S.MoldelsView
{
    public class CalendarioMV
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; } = null!;

        public string Barrio { get; set; } = null!;

        public string TipoTutoria { get; set; } = null!;

    }
}