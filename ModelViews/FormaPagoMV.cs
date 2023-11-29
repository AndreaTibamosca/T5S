namespace T5S.MoldelsView
{
    public class FormaPagoMV
    {

        public int Id { get; set; }

        public string TipoPago { get; set; }

        public int ValoraPagar { get; set; }

        public string Estado { get; set; } = null!;
    }
}