using System.Collections.Generic;
using Telerik.Windows.Controls;
using System.Windows.Controls;
using Telerik.Windows.Data;
using System.Windows;
using RAI.ViewModel;
using System.Linq;
using RAI.API;
using System;

namespace RAI.Pages.Cadastros.Locais
{
    public partial class PageLocais : UserControl
    {
        private List<Local> locais_inativos { get; set; }
        private List<Local> locais_ativos { get; set; }
        private List<Cultura> culturas { get; set; }
        private List<Variedade> variedades { get; set; }
        private bool inativos = false;

        public PageLocais()
        {
            InitializeComponent();
        }

        private async void CarregaLocais()
        {
            pb.Visibility = Visibility.Visible;

            if (inativos)
            {
                if (locais_inativos == null)
                    locais_inativos = await CadastroAPI.GetLocaisAsync(somenteInativos: true);

                grid.ItemsSource = locais_inativos;
            }
            else
            {
                if (locais_ativos == null)
                    locais_ativos = await CadastroAPI.GetLocaisAsync();

                grid.ItemsSource = locais_ativos;
            }

            pb.Visibility = Visibility.Hidden;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            tabLocais.IsSelected = true;
            locais_ativos = null;
            locais_inativos = null;

            culturas = null;
            variedades = null;

            CarregaLocais();
        }

        private async void RadTabControl_SelectionChanged(object sender, RadSelectionChangedEventArgs e)
        {
            if (tab.SelectedItem == null) return;

            if (tab.SelectedItem == tabLocais) return;

            if (tab.SelectedItem == tabCulturas)
            {
                if (culturas != null) return;

                CarregarCulturas();
            }
            else if (tab.SelectedItem == tabVariedades)
            {
                if (variedades != null) return;

                pbVariedades.Visibility = Visibility.Visible;

                variedades = await CadastroAPI.GetVariedadesAsync();
                gridVariedades.ItemsSource = variedades;

                pbVariedades.Visibility = Visibility.Collapsed;
            }
        }

        private async void CarregarCulturas()
        {
            pbCultura.Visibility = Visibility.Visible;
            culturas = await CadastroAPI.GetCulturasAsync();
            gridCultura.ItemsSource = culturas;
            pbCultura.Visibility = Visibility.Collapsed;
        }

        private void btInativos_Click(object sender, RoutedEventArgs e)
        {
            inativos = !inativos;

            if (inativos)
                btInativos.Content = "Talhões Ativos";
            else
                btInativos.Content = "Talhões Inativos";

            CarregaLocais();
        }

        private void btNovo_Click(object sender, RoutedEventArgs e)
        {
            ret.Visibility = Visibility.Visible;

            var window = new PageLocalInclude();
            window.ShowDialog();

            if (window.gravou)
            {
                if (window.local.inativo)
                {
                    if (locais_inativos != null) locais_inativos.Add(window.local);
                }
                else
                    locais_ativos.Add(window.local);

                grid.Rebind();
                Helper.ShowSnack(snack, "Incluído com sucesso");
            }

            ret.Visibility = Visibility.Collapsed;
        }

        private void ButtonColumnEditLocal_CustomClick(object sender, RoutedEventArgs e)
        {
            if (sender == null) return;

            ret.Visibility = Visibility.Visible;

            var local = sender as Local;
            grid.SelectedItem = local;

            var window = new PageLocalInclude();
            window.local = local;
            window.ShowDialog();

            if (window.gravou)
            {
                if (window.local.inativo != inativos)
                {
                    if (inativos)
                    {
                        locais_inativos.Remove(local);
                        locais_ativos.Add(local);
                    }
                    else
                    {
                        locais_ativos.Remove(local);
                        if (locais_inativos != null) locais_inativos.Add(local);
                    }
                }

                grid.Rebind();
                Helper.ShowSnack(snack, "Alterado com sucesso");
            }

            ret.Visibility = Visibility.Collapsed;
        }

        private async void ButtonColumnDelete_DeleteClick(object sender, RoutedEventArgs e)
        {
            if (sender == null) return;

            var local = sender as Local;

            try
            {
                await CadastroAPI.DeleteLocalAsync(local.id);

                if (inativos)
                    locais_inativos.Remove(local);
                else
                    locais_ativos.Remove(local);

                grid.Rebind();
                Helper.ShowSnack(snack, "Excluído com sucesso");
            }
            catch (Exception ex)
            {
                //LogError.GenerateLog(local, this.Name);
                Helper.ShowPonDialog(ex.Message, tipoMensagem: MessageBoxImage.Exclamation);
            }
        }

        private void btImprimir_Click(object sender, RoutedEventArgs e)
        {
            if (grid == null || grid.Items == null)
            {
                Helper.ShowPonDialog("Não foi localizado nenhum Local!");
                return;
            }

            pb.Visibility = Visibility.Visible;

            var consultaFiltro = Helper.GetItemsGrid<Local>(grid);

            pb.Visibility = Visibility.Hidden;

            if (consultaFiltro == null || consultaFiltro.Count == 0)
            {
                Helper.ShowPonDialog("Não foi localizado nenhum Local!");
                return;
            }

            Helper.ShowReport(new ReportLocais(consultaFiltro), titulo: "Listagem de Talhões");
        }

        private void btMapa_CustomClick(object sender, RoutedEventArgs e)
        {
            if (sender == null) return;

            ret.Visibility = Visibility.Visible;

            var local = sender as Local;
            grid.SelectedItem = local;

            var window = new PageLocalMapeamento();
            window.local = local;
            window.ShowDialog();

            if (window.gravou)
            {
                local.mapeado = true;
                grid.Rebind();
                Helper.ShowSnack(snack, "Gravado com sucesso");
            }

            ret.Visibility = Visibility.Collapsed;
        }

        private void btNovaVariedade_Click(object sender, RoutedEventArgs e)
        {
            ret.Visibility = Visibility.Visible;

            //var window = new PageVariedadeInclude();
            //window.ShowDialog();

            //if (window.gravou)
            //{
            //    variedades.Add(window.variedade);
            //    gridVariedades.Rebind();
            //    Helper.ShowSnack(snackVariedade, "Incluído com sucesso");
            //}

            ret.Visibility = Visibility.Collapsed;
        }

        private void ButtonEditVariedade_CustomClick(object sender, RoutedEventArgs e)
        {
            if (sender == null) return;

            //var variedade = sender as Variedade;
            //gridVariedades.SelectedItem = variedade;

            //if (variedade.cliente_id == null)
            //{
            //    Helper.ShowSnack(snackVariedade, "Variedade interna do sistema não pode ser editada");
            //    return;
            //}

            //ret.Visibility = Visibility.Visible;

            //var window = new PageVariedadeInclude();
            //window.variedade = variedade;
            //window.ShowDialog();

            //if (window.gravou)
            //{
            //    gridVariedades.Rebind();
            //    Helper.ShowSnack(snackVariedade, "Alterada com sucesso");
            //}

            ret.Visibility = Visibility.Collapsed;
        }

        private async void ButtonDeleteVariedade_DeleteClick(object sender, RoutedEventArgs e)
        {
            //if (sender == null) return;

            //var variedade = sender as Variedade;
            //if (variedade.cliente_id == null)
            //{
            //    Helper.ShowSnack(snackVariedade, "Variedade interna do sistema não pode ser excluída");
            //    return;
            //}

            //try
            //{
            //    await CadastroAPI.DeleteVariedadeAsync(variedade.id);
            //    gridVariedades.Items.Remove(variedade);
            //    Helper.ShowSnack(snackVariedade, "Excluída com sucesso");
            //}
            //catch (Exception ex)
            //{
            //    //LogError.GenerateLog(variedade, this.Name);
            //    Helper.ShowPonDialog(ex.Message, tipoMensagem: MessageBoxImage.Exclamation);
            //}
        }

        private async void ButtonColumnDelete_DeleteClick_1(object sender, RoutedEventArgs e)
        {
            //if (sender == null) return;

            //var cultura = sender as Cultura;

            //try
            //{
            //    await CadastroAPI.DeleteCulturaAsync(cultura.id);
            //    culturas.Remove(cultura);
            //    Helper.user.culturas = Helper.user.culturas.Where(w => w.cultura_id != cultura.id).ToList();
            //    gridCultura.Rebind();

            //    Helper.ShowSnack(snackCultura, "Excluído com sucesso");
            //}
            //catch (Exception ex)
            //{
            //    //LogError.GenerateLog(cultura, this.Name);
            //    Helper.ShowPonDialog(ex.Message, tipoMensagem: MessageBoxImage.Exclamation);
            //}
        }

        private void btVincularCultura_Click(object sender, RoutedEventArgs e)
        {
            //ret.Visibility = Visibility.Visible;

            //var window = new PageVincularCultura();
            //window.ShowDialog();

            //if (window.gravou)
            //{
            //    CarregarCulturas();
            //    Helper.ShowSnack(snackVariedade, "Culturas Vinculadas com sucesso");
            //}

            //ret.Visibility = Visibility.Collapsed;
        }
    }

    public class MyPlantasHectareFunction : AggregateFunction<Local, decimal>
    {
        public MyPlantasHectareFunction()
        {
            this.AggregationExpression = locais => locais.Where(f => f.hectares > 0 && f.plantas > 0).Sum(c => c.hectares.GetValueOrDefault()) == 0 ? 0 : locais.Where(f => f.hectares > 0 && f.plantas > 0).Sum(p => p.plantas.GetValueOrDefault()) / locais.Where(f => f.hectares > 0 && f.plantas > 0).Sum(c => c.hectares.GetValueOrDefault());
            this.ResultFormatString = "{0:N0}";
        }
    }
}