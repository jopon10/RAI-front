using System;

namespace RAI.ViewModel
{
    public class Local 
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nome { get; set; }
        public int? fazenda_id { get; set; }
        public int? cultura_id { get; set; }

        public int? variedade_id { get; set; }
        public string variedade { get; set; }

        public string fazenda { get; set; }
        public string cultura { get; set; }
        public decimal? hectares { get; set; }
        public int? plantas { get; set; }
        public decimal? plantas_hectare { get; set; }

        public decimal? espacamento_linha { get; set; }
        public decimal? espacamento_planta { get; set; }

        public string espacamento { get => espacamento_linha > 0 ? $"{espacamento_linha.GetValueOrDefault().ToString("N2")} x {espacamento_planta}" : ""; }

        public DateTime? data_plantio { get; set; }
        public int? idade { get; set; }

        public string cidade { get; set; }
        public bool inativo { get; set; }

        public int? tipo_local { get; set; }
        public string tipo_local_tela
        {
            get
            {
                switch (tipo_local)
                {
                    case 0: return "Lavoura";
                    case 3: return "Benfeitoria";
                    case 4: return "Outro";

                    default: return "";
                };
            }
        }

        public string coordenadas { get; set; }
        public bool mapeado { get; set; }

        public string nome_mapa { get => $"{nome}\n{hectares.GetValueOrDefault().ToString("N2")} ha"; }
        public string toolTip_mapa
        {
            get
            {
                string toolTip = $"{nome}\nHectares: {hectares.GetValueOrDefault().ToString("N2")}";

                if (cultura != null && cultura.Trim().Length > 0) toolTip += $"\nCultura: {cultura}";
                if (variedade != null && variedade.Trim().Length > 0) toolTip += $"\nVariedade: {variedade}";
                if (plantas.GetValueOrDefault() > 0) toolTip += $"\nPlantas: {plantas.GetValueOrDefault().ToString("N0")}";
                if (plantas_hectare.GetValueOrDefault() > 0) toolTip += $"\nPlantas / HA: {plantas_hectare.GetValueOrDefault().ToString("N0")}";
                if (data_plantio != null) toolTip += $"\nData Plantio: {data_plantio.Value.ToShortDateString()}";
                if (espacamento != null && espacamento.Trim().Length > 0) toolTip += $"\nEspaçamento: {espacamento}";

                return toolTip;
            }
        }

        public Local Clone()
        {
            return (Local)this.MemberwiseClone();
        }
    }
}