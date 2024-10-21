using Telerik.Windows.Controls;

namespace RAI.Localization
{
    public class CustomLocalizationManager : LocalizationManager
    {
        public override string GetStringOverride(string key)
        {
            switch (key)
            {
                case "GridViewSearchPanelTopText":
                    return "Pesquisar";
                case "GridViewAlwaysVisibleNewRow":
                    return "Adicionar novo ítem";
                case "GridViewClearFilter":
                    return "Limpar Filtro";
                case "GridViewFilterSelectAll":
                    return "Todos";
                case "GridViewFilterDistinctValueNull":
                    return "Vazio";
                case "GridViewFilterDistinctValueStringEmpty":
                    return "Vazio";
                case "Day":
                    return "Dia";
                case "Week":
                    return "Semana";
                case "Month":
                    return "Mês";
            }

            return base.GetStringOverride(key);
        }
    }
}