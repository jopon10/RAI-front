namespace RAI.ViewModel
{
    public class Cultura
    {
        public bool selecionado { get; set; }
        public int id { get; set; }
        public string nome { get; set; }
        public int? cliente_id { get; set; }
    }

    public class Variedade
    {
        public int id { get; set; }
        public string nome { get; set; }

        public int? cliente_id { get; set; }

        public int cultura_id { get; set; }
        public string cultura { get; set; }

        public decimal? hectares { get; set; }
        public decimal? qtde_locais { get; set; }
    }
}