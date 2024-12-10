using Telerik.Windows.Controls.ChartView;
using System.Collections.Generic;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls;
using System.Windows;
using RAI.ViewModel;
using RAI.Controls;
using System.Linq;
using RAI.API;
using System;

namespace RAI.Pages.Agricola.AnalisesSolo
{
    public partial class PageAnaliseSolo : UserControl
    {
        public List<AnaliseSolo> analises { get; set; }
        public List<AnaliseSolo> consulta { get; set; }
        public List<AnaliseSolo> consulta_filtro { get; set; }

        public List<Parceiro> parceiros { get; set; }
        public List<Local> locais { get; set; }

        public PageAnaliseSolo()
        {
            InitializeComponent();

            dt.Culture = new System.Globalization.CultureInfo("pt-BR");
            dt.Culture.DateTimeFormat.ShortDatePattern = "MMM-yyyy";

            dt.SelectedDate = DateTime.Today;
            dt.SelectionChanged += dt_SelectionChanged;

            d1.SelectedDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            d2.SelectedDate = d1.SelectedDate?.AddMonths(1).AddDays(-1);
        }

        private async void CarregaAnalises()
        {
            pb.Visibility = Visibility.Visible;

            var date = new DateTime(dt.SelectedDate.Value.Year, dt.SelectedDate.Value.Month, 1);
            analises = await AgricolaAPI.GetAnalisesSoloAsync(date, date.AddMonths(1).AddDays(-1));
            grid.ItemsSource = analises;

            pb.Visibility = Visibility.Collapsed;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            tabAnalises.IsSelected = true;
            parceiros = null;
            locais = null;

            CarregaAnalises();
        }

        private async void RadTabControl_SelectionChanged(object sender, Telerik.Windows.Controls.RadSelectionChangedEventArgs e)
        {
            if (tab.SelectedItem == null) return;

            if (tab.SelectedItem == tabAnalises) return;

            if (tab.SelectedItem == tabConsulta)
            {
                if (locais == null)
                    locais = await CadastroAPI.GetLocaisAsync(minimal: true);

                cbLocais.ItemsSource = locais;
            }
        }

        private void dt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarregaAnalises();
        }

        private void btNovo_Click(object sender, RoutedEventArgs e)
        {
            ret.Visibility = Visibility.Visible;

            var window = new PageAnaliseSoloInclude();
            window.parceiros = parceiros;
            window.locais = locais;
            window.ShowDialog();

            parceiros = window.parceiros;
            locais = window.locais;

            if (window.gravou)
            {
                analises.Add(window.analise);
                grid.Rebind();
                Helper.ShowSnack(snack, "Incluído com sucesso");
            }

            ret.Visibility = Visibility.Collapsed;
        }

        private void ButtonColumnEdit_CustomClick(object sender, RoutedEventArgs e)
        {
            if (sender == null) return;

            ret.Visibility = Visibility.Visible;

            var analise = sender as AnaliseSolo;
            grid.SelectedItem = analise;

            var window = new PageAnaliseSoloInclude();
            window.analise = analise;
            window.parceiros = parceiros;
            window.locais = locais;
            window.ShowDialog();

            parceiros = window.parceiros;
            locais = window.locais;

            if (window.gravou)
            {
                grid.Rebind();
                Helper.ShowSnack(snack, "Alterado com sucesso");
            }

            ret.Visibility = Visibility.Collapsed;
        }

        private async void ButtonColumnDelete_DeleteClick(object sender, RoutedEventArgs e)
        {
            if (sender == null) return;

            var analise = sender as AnaliseSolo;

            try
            {
                await CadastroAPI.DeleteFazendaAsync(analise.id);
                grid.Items.Remove(analise);
                Helper.ShowSnack(snack, "Excluído com sucesso");
            }
            catch (Exception ex)
            {
                //LogError.GenerateLog(fazenda, this.Name);
                Helper.ShowPonDialog(ex.Message, tipoMensagem: MessageBoxImage.Exclamation);
            }
        }

        private void btCalagem_CustomClick(object sender, RoutedEventArgs e)
        {
            if (sender == null) return;

            ret.Visibility = Visibility.Visible;

            var analise = sender as AnaliseSolo;
            grid.SelectedItem = analise;

            var window = new PageCorrecaoCalagemInclude();
            window.analise = analise;
            window.ShowDialog();

            if (window.gravou)
            {
                grid.Rebind();
                Helper.ShowSnack(snack, "Salvo com sucesso");
            }

            ret.Visibility = Visibility.Collapsed;
        }

        private async void btFiltrar_Click(object sender, RoutedEventArgs e)
        {
            if (d1.SelectedDate == null)
            {
                d1.Focus();
                return;
            }

            if (d2.SelectedDate == null)
            {
                d2.Focus();
                return;
            }

            if (cbLocais.SelectedItem == null)
            {
                cbLocais.Focus();
                return;
            }

            try
            {
                btFiltrar.IsLoading(true);

                var local = cbLocais.SelectedItem as Local;

                consulta = await AgricolaAPI.GetAnalisesSoloAsync(d1.SelectedDate.Value, d2.SelectedDate.Value, local);
                gridConsulta.ItemsSource = consulta;
                if (iconGrafico.Kind == PackIconKind.FormatListBulleted) CarregaGraficoLista();

                if (consulta.Count == 0) Helper.ShowSnack(snackConsulta, "Nenhuma informação encontrada no período!");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                btFiltrar.IsLoading(false);
            }
        }

        #region Grafico
        private void btGrafico_Click(object sender, RoutedEventArgs e)
        {
            if (iconGrafico.Kind == PackIconKind.ChartBar)
            {
                iconGrafico.Kind = PackIconKind.FormatListBulleted;
                btGrafico.ToolTip = "Lista";
                gridConsulta.Visibility = Visibility.Collapsed;
                panelChart.Visibility = Visibility.Visible;
                //btRelatorioGrafico.IsEnabled = true;
                CarregaGraficoLista();
            }
            else
            {
                iconGrafico.Kind = PackIconKind.ChartBar;
                btGrafico.ToolTip = "Gráfico";
                gridConsulta.Visibility = Visibility.Visible;
                panelChart.Visibility = Visibility.Collapsed;
                //btRelatorioGrafico.IsEnabled = false;
            }
        }

        private void CarregaGraficoLista()
        {
            consulta_filtro = new List<AnaliseSolo>();

            if ((grid != null || grid.Items != null) && grid.Items.Count > 0)
                consulta_filtro = Helper.GetItemsGrid<AnaliseSolo>(gridConsulta);
            else
                consulta_filtro = consulta.ToList();

            chart.Series.Clear();

            foreach (var item in consulta_filtro)
            {
                var barSeries = new BarSeries() { ShowLabels = true };
                ChartAnimationUtilities.SetCartesianAnimation(barSeries, CartesianAnimation.RiseWithDelay);

                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.ph.GetValueOrDefault(), Label = item.ph.GetValueOrDefault().ToString("N0"), Category = "pH", CategoryComplete = "pH" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.mo.GetValueOrDefault(), Label = item.mo.GetValueOrDefault().ToString("N0"), Category = "M.O.", CategoryComplete = "M.O." });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.p.GetValueOrDefault(), Label = item.p.GetValueOrDefault().ToString("N0"), Category = "P", CategoryComplete = "pH" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.k.GetValueOrDefault(), Label = item.k.GetValueOrDefault().ToString("N0"), Category = "K", CategoryComplete = "K" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.ca.GetValueOrDefault(), Label = item.ca.GetValueOrDefault().ToString("N0"), Category = "Ca", CategoryComplete = "Ca" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.mg.GetValueOrDefault(), Label = item.mg.GetValueOrDefault().ToString("N0"), Category = "Mg", CategoryComplete = "Mg" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.na.GetValueOrDefault(), Label = item.na.GetValueOrDefault().ToString("N0"), Category = "Na", CategoryComplete = "Na" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.h_al.GetValueOrDefault(), Label = item.h_al.GetValueOrDefault().ToString("N0"), Category = "H+Al", CategoryComplete = "H+Al" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.al.GetValueOrDefault(), Label = item.al.GetValueOrDefault().ToString("N0"), Category = "Al", CategoryComplete = "Al" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.ctc, Label = item.ctc.ToString("N0"), Category = "CTC", CategoryComplete = "CTC" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.sb, Label = item.sb.ToString("N0"), Category = "S.B.", CategoryComplete = "S.B." });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.v, Label = item.v.ToString("N0"), Category = "V%", CategoryComplete = "V%" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.ca_ctc, Label = item.ca_ctc.ToString("N0"), Category = "Ca%", CategoryComplete = "Ca%" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.mg_ctc, Label = item.mg_ctc.ToString("N0"), Category = "Mg%", CategoryComplete = "Mg%" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.k_ctc, Label = item.k_ctc.ToString("N0"), Category = "K%", CategoryComplete = "K%" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.m, Label = item.m.ToString("N0"), Category = "m%", CategoryComplete = "m%" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.s.GetValueOrDefault(), Label = item.s.GetValueOrDefault().ToString("N0"), Category = "S", CategoryComplete = "S" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.b.GetValueOrDefault(), Label = item.b.GetValueOrDefault().ToString("N0"), Category = "B", CategoryComplete = "B" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.cu.GetValueOrDefault(), Label = item.cu.GetValueOrDefault().ToString("N0"), Category = "Cu", CategoryComplete = "Cu" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.fe.GetValueOrDefault(), Label = item.fe.GetValueOrDefault().ToString("N0"), Category = "Fe", CategoryComplete = "Fe" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.mn.GetValueOrDefault(), Label = item.mn.GetValueOrDefault().ToString("N0"), Category = "Mn", CategoryComplete = "Mn" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.zn.GetValueOrDefault(), Label = item.zn.GetValueOrDefault().ToString("N0"), Category = "Zn", CategoryComplete = "Zn" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.argila.GetValueOrDefault(), Label = item.argila.GetValueOrDefault().ToString("N0"), Category = "Argila", CategoryComplete = "Argila" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.silte.GetValueOrDefault(), Label = item.silte.GetValueOrDefault().ToString("N0"), Category = "Silte", CategoryComplete = "Silte" });
                barSeries.DataPoints.Add(new PonDataPoint() { Value = (double)item.areia.GetValueOrDefault(), Label = item.areia.GetValueOrDefault().ToString("N0"), Category = "Areia", CategoryComplete = "Areia" });

                chart.Series.Add(barSeries);
            }
        }
        #endregion
    }
}