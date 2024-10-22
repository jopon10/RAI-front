using System;

namespace RAI.ViewModel
{
    public class Parceiro
    {
        public int id { get; set; }

        public bool cliente { get; set; }
        public bool fornecedor { get; set; }

        public string nome_display_combo { get => codigo_parceiro != null ? $"{codigo_parceiro} - {nome}  {cpf_cnpj.FormatarCnpjCpf()}" : $"{nome}  {cpf_cnpj.FormatarCnpjCpf()}"; }
        public string codigo_parceiro { get; set; }
        public string nome { get; set; }
        public string fantasia { get; set; }

        public string email { get; set; }
        public string celular { get; set; }
        public DateTime? nascimento { get; set; }
        public string cpf_cnpj { get; set; }

        public string cep { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }

        public int? cidade_id { get; set; }
        public string cidade { get; set; }

        public int? estado_id { get; set; }
        public string estado { get; set; }

        public string endereco_completo { get => $"{endereco}, {numero}, {bairro}, {cidade}, {cep}"; }

        public bool inativo { get; set; }
    }
}