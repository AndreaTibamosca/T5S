using T5S.Models;

namespace T5S.ModelsView
{
    public class RepositorioMV
    {
        public int Id { get; set; }

        public string NombreRepositorio { get; set; } = null!;

        public string NombreTutor { get; set; } = null!;

        public string MediosRepositorio { get; set; } = null!;

        public string Estado { get; set; } = null!;

    }
}
