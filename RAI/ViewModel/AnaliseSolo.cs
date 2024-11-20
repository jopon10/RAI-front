using System;

namespace RAI.ViewModel
{
    public class AnaliseSolo
    {
        public int id { get; set; }

        public int parceiro_id { get; set; }
        public string parceiro { get; set; }

        public int fazenda_id { get; set; }
        public string fazenda { get; set; }

        public int local_id { get; set; }
        public string local { get; set; }

        public int? quadra_id { get; set; }
        public string quadra { get; set; }

        public DateTime data { get; set; }
        public string profundidade { get; set; }
        public string observacao { get; set; }

        public decimal? ph { get; set; }
        public decimal? mo { get; set; }
        public decimal? p { get; set; }
        public decimal? k { get; set; }
        public decimal? ca { get; set; }
        public decimal? mg { get; set; }
        public decimal? na { get; set; }
        public decimal? h_al { get; set; }
        public decimal? al { get; set; }
        public decimal? s { get; set; }
        public decimal? b { get; set; }
        public decimal? cu { get; set; }
        public decimal? fe { get; set; }
        public decimal? mn { get; set; }
        public decimal? zn { get; set; }
        public decimal? argila { get; set; }
        public decimal? silte { get; set; }
        public decimal? areia { get; set; }

        public string ph_extrator { get; set; }
        public string p_extrator { get; set; }
        public string k_extrator { get; set; }
        public string cu_extrator { get; set; }
        public string fe_extrator { get; set; }
        public string mn_extrator { get; set; }
        public string zn_extrator { get; set; }

        public string mo_unidade { get; set; }
        public string k_unidade { get; set; }
        public string ca_unidade { get; set; }
        public string mg_unidade { get; set; }
        public string na_unidade { get; set; }
        public string h_al_unidade { get; set; }
        public string al_unidade { get; set; }
        public string cu_unidade { get; set; }
        public string fe_unidade { get; set; }
        public string mn_unidade { get; set; }
        public string zn_unidade { get; set; }
        public string argila_unidade { get; set; }
        public string silte_unidade { get; set; }
        public string areia_unidade { get; set; }

        public decimal sb { get => k.GetValueOrDefault() + ca.GetValueOrDefault() + mg.GetValueOrDefault(); }
        public decimal ctc { get => h_al.GetValueOrDefault() + sb; }
        public decimal t { get => sb + al.GetValueOrDefault(); }
        public decimal v { get => ctc > 0 ? (100 * sb) / ctc : 0; }
        public decimal m { get => t > 0 ? (100 * al.GetValueOrDefault()) / t : 0; }
        public decimal ca_ctc { get => ctc > 0 ? ca.GetValueOrDefault() / ctc * 100 : 0; }
        public decimal mg_ctc { get => ctc > 0 ? mg.GetValueOrDefault() / ctc * 100 : 0; }
        public decimal k_ctc { get => ctc > 0 ? k.GetValueOrDefault() / ctc * 100 : 0; }
    }
}