namespace RAI.ViewModel
{
    public class Proprietario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string fantasia { get; set; }
        public string cpf_cnpj { get; set; }
        public bool inativo { get; set; }

        public string email { get; set; }
        public string celular { get; set; }

        public string cep { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }

        public string codigo_cidade { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }

        public int? estado_id { get; set; }
        public int? cidade_id { get; set; }

        public Proprietario Clone()
        {
            return (Proprietario)this.MemberwiseClone();
        }
    }
}