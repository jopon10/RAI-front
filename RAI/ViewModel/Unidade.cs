namespace RAI.ViewModel
{
    public class Unidade
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }

        public int? unidade_id { get; set; }
        public string unidade { get; set; }
        public decimal? multiplicador { get; set; }
        public int? cliente_id { get; set; }
    }
}