using T5S.Models;

namespace T5S.MoldelsView
{
    public class TutorMV
    {
        public int IdTutor { get; set; }

        public string NombreTutor { get; set; } = null!;

        public string ApellidoTutor { get; set; } = null!;

        public int NumeroDocumentoTutor { get; set; }

        public string CorreoTutor { get; set; } = null!;

        public string NombreMateria { get; set; } = null!;

        public string CostoMateria { get; set; } = null!;

        public string Estado { get; set; } = null!;

    }
}
