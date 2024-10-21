namespace RAI.ViewModel
{
    public class Estado
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sigla { get; set; }
    }

    public class Cidade
    {
        public int id { get; set; }
        public int estado_id { get; set; }
        public string nome { get; set; }
        public string ibge { get; set; }
        public string ibge7 { get; set; }
    }
}