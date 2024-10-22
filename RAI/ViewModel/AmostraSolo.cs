using System;

namespace RAI.ViewModel
{
    public class AmostraSolo
    {
        public int id { get; set; }

        public DateTime data { get; set; }

        public string descricao { get; set; }

        public int local_id { get; set; }
        public string nome { get; set; }

        public decimal profundidade { get; set; }

        public double? latitude { get; set; }
        public double? longitude { get; set; }

        public int? analise_solo_id { get; set; }
    }
}