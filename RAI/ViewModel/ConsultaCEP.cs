namespace RAI.ViewModel
{
    public class ConsultaCEP
    {
        public string cep { get; set; }
        public string tipo { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }
        public string nome_localidade { get; set; }
        public string codigo_ibge { get; set; }
        public string tipo_logradouro { get; set; }
        public string nome_logradouro { get; set; }
        public string bairro { get; set; }
        public string descricao { get; set; }

        public string endereco { get => $"{tipo_logradouro} {nome_logradouro}"; }
    }
}