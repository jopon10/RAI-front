using System.Collections.Generic;

namespace RAI.ViewModel
{
    public class Fazenda
    {
        public Fazenda()
        {
            culturas = new List<Cultura>();
            locais = new List<Local>();
        }

        public int id { get; set; }
        public string nome { get; set; }
        public bool inativa { get; set; }

        public string cep { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }

        public int estado_id { get; set; }
        public int cidade_id { get; set; }

        public string estado { get; set; }
        public string cidade { get; set; }
        public string codigo_cidade { get; set; }

        public decimal? hectares { get; set; }
        public decimal? qtde_locais { get; set; }
        public string lat_long { get; set; }

        public List<Cultura> culturas { get; set; }
        public List<Local> locais { get; set; }
    }
}