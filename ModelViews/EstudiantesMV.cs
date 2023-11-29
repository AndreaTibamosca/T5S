using Microsoft.VisualBasic;

namespace T5S.ModelViews
{
    public class EstudiantesMV
    {
        public int id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }
         
        public string TipoDocumento { get; set; }

        public int Numero { get; set; }

        public int Celular { get; set; }
        public string Correo { get; set; }

        public string Estado { get; set; } = null!;

    }

}
