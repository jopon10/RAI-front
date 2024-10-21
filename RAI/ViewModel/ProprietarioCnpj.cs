namespace RAI.ViewModel
{
    public class ProprietarioCnpj
    {
        public string razao_social { get; set; }
        public string cnpj { get; set; }
        public string situacao_cadastral { get; set; }
        public string cnae_principal { get; set; }
        public ProprietarioEndereco endereco { get; set; }
    }

    public class ProprietarioEndereco
    {
        public string codigo_municipio { get; set; }
        public string nome_municipio { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string uf { get; set; }
    }
}