namespace T5S.ModelViews
{
    public class LoginMV
    {

        public string Nombreusuario { get; set; }

        public string Password { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string TipoDocumento { get; set; } = null!;

        public string NumeroDocumento { get; set; } = null!;

        public string Estado { get; set; } = null!;

        public int Id { get; set;} = 0;


    }
}
