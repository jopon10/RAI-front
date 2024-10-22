namespace RAI.ViewModel
{
    public class Nutriente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sigla { get; set; }
        public string nome_sigla { get => $"{nome} - {sigla}"; }
    }
}