namespace RAI.ViewModel
{
    public class AnaliseSoloResultado
    {
        public int id { get; set; }

        public int analise_solo_id { get; set; }

        public int? amostra_id { get; set; }
        public string amostra { get; set; }

        public int? local_id { get; set; }
        public string local { get; set; }
        public decimal? profundidade { get; set; }

        public int nutriente_id { get; set; }
        public string nutriente { get; set; }

        public decimal quantidade { get; set; }
    }
}