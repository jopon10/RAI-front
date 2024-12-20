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

            if ((gridConsulta != null || gridConsulta.Items != null) && gridConsulta.Items.Count > 0)
                consulta_filtro = Helper.GetItemsGrid<AnaliseSolo>(gridConsulta);
            else
                consulta_filtro = consulta.ToList();

            chart.Series.Clear();

            bool PV = true;

            var tbiTemplate = GridLayoutChart.Resources["trackBallTemplate"] as DataTemplate;
            var tbiTemplate2 = GridLayoutChart.Resources["trackBallTemplate2"] as DataTemplate;

            foreach (var item in consulta_filtro)
            {
                var dtAux = tbiTemplate2;
                if (PV) dtAux = tbiTemplate;
                PV = false;

                var barPH = new BarSeries() { ShowLabels = true, TrackBallInfoTemplate = dtAux, DefaultVisualStyle = item.style_ph };
                var barP = new BarSeries() { ShowLabels = true, TrackBallInfoTemplate = dtAux, DefaultVisualStyle = item.style_p };
                var barK = new BarSeries() { ShowLabels = true, TrackBallInfoTemplate = dtAux, DefaultVisualStyle = item.style_k };
                var barCA = new BarSeries() { ShowLabels = true, TrackBallInfoTemplate = dtAux, DefaultVisualStyle = item.style_ca };
                var barMG = new BarSeries() { ShowLabels = true, TrackBallInfoTemplate = dtAux, DefaultVisualStyle = item.style_mg };
                var barS = new BarSeries() { ShowLabels = true, TrackBallInfoTemplate = dtAux, DefaultVisualStyle = item.style_s };
                var barCTC = new BarSeries() { ShowLabels = true, TrackBallInfoTemplate = dtAux, DefaultVisualStyle = item.style_ctc };
                var barMGCTC = new BarSeries() { ShowLabels = true, TrackBallInfoTemplate = dtAux, DefaultVisualStyle = item.style_mg };
                var barCACTC = new BarSeries() { ShowLabels = true, TrackBallInfoTemplate = dtAux, DefaultVisualStyle = item.style_ca };
                var barKCTC = new BarSeries() { ShowLabels = true, TrackBallInfoTemplate = dtAux, DefaultVisualStyle = item.style_k };
                var barV = new BarSeries() { ShowLabels = true, TrackBallInfoTemplate = dtAux, DefaultVisualStyle = item.style_v };
                var barMO = new BarSeries() { ShowLabels = true, TrackBallInfoTemplate = dtAux, DefaultVisualStyle = item.style_mo };
                var barZN = new BarSeries() { ShowLabels = true, TrackBallInfoTemplate = dtAux, DefaultVisualStyle = item.style_zn };
                var barFE = new BarSeries() { ShowLabels = true, TrackBallInfoTemplate = dtAux, DefaultVisualStyle = item.style_fe };
                var barMN = new BarSeries() { ShowLabels = true, TrackBallInfoTemplate = dtAux, DefaultVisualStyle = item.style_mn };
                var barCU = new BarSeries() { ShowLabels = true, TrackBallInfoTemplate = dtAux, DefaultVisualStyle = item.style_cu };
                var barB = new BarSeries() { ShowLabels = true, TrackBallInfoTemplate = dtAux, DefaultVisualStyle = item.style_b };
                var barAL = new BarSeries() { ShowLabels = true, TrackBallInfoTemplate = dtAux, DefaultVisualStyle = item.style_al };
                var barHAL = new BarSeries() { ShowLabels = true, TrackBallInfoTemplate = dtAux, DefaultVisualStyle = item.style_h_al };

                ChartAnimationUtilities.SetCartesianAnimation(barPH, CartesianAnimation.RiseWithDelay);
                ChartAnimationUtilities.SetCartesianAnimation(barP, CartesianAnimation.RiseWithDelay);
                ChartAnimationUtilities.SetCartesianAnimation(barK, CartesianAnimation.RiseWithDelay);
                ChartAnimationUtilities.SetCartesianAnimation(barCA, CartesianAnimation.RiseWithDelay);
                ChartAnimationUtilities.SetCartesianAnimation(barMG, CartesianAnimation.RiseWithDelay);
                ChartAnimationUtilities.SetCartesianAnimation(barS, CartesianAnimation.RiseWithDelay);
                ChartAnimationUtilities.SetCartesianAnimation(barCTC, CartesianAnimation.RiseWithDelay);
                ChartAnimationUtilities.SetCartesianAnimation(barMGCTC, CartesianAnimation.RiseWithDelay);
                ChartAnimationUtilities.SetCartesianAnimation(barCACTC, CartesianAnimation.RiseWithDelay);
                ChartAnimationUtilities.SetCartesianAnimation(barKCTC, CartesianAnimation.RiseWithDelay);
                ChartAnimationUtilities.SetCartesianAnimation(barV, CartesianAnimation.RiseWithDelay);
                ChartAnimationUtilities.SetCartesianAnimation(barMO, CartesianAnimation.RiseWithDelay);
                ChartAnimationUtilities.SetCartesianAnimation(barZN, CartesianAnimation.RiseWithDelay);
                ChartAnimationUtilities.SetCartesianAnimation(barFE, CartesianAnimation.RiseWithDelay);
                ChartAnimationUtilities.SetCartesianAnimation(barMN, CartesianAnimation.RiseWithDelay);
                ChartAnimationUtilities.SetCartesianAnimation(barCU, CartesianAnimation.RiseWithDelay);
                ChartAnimationUtilities.SetCartesianAnimation(barB, CartesianAnimation.RiseWithDelay);
                ChartAnimationUtilities.SetCartesianAnimation(barAL, CartesianAnimation.RiseWithDelay);
                ChartAnimationUtilities.SetCartesianAnimation(barHAL, CartesianAnimation.RiseWithDelay);

                barPH.DataPoints.Add(new PonDataPoint() { Value = (double)item.ph.GetValueOrDefault(), Label = item.ph.GetValueOrDefault().ToString("N0"), Category = "pH", CategoryComplete = "pH" });
                barP.DataPoints.Add(new PonDataPoint() { Value = (double)item.p.GetValueOrDefault(), Label = item.p.GetValueOrDefault().ToString("N0"), Category = "P", CategoryComplete = "pH" });
                barK.DataPoints.Add(new PonDataPoint() { Value = (double)item.k.GetValueOrDefault(), Label = item.k.GetValueOrDefault().ToString("N0"), Category = "K", CategoryComplete = "K" });
                barCA.DataPoints.Add(new PonDataPoint() { Value = (double)item.ca.GetValueOrDefault(), Label = item.ca.GetValueOrDefault().ToString("N0"), Category = "Ca", CategoryComplete = "Ca" });
                barMG.DataPoints.Add(new PonDataPoint() { Value = (double)item.mg.GetValueOrDefault(), Label = item.mg.GetValueOrDefault().ToString("N0"), Category = "Mg", CategoryComplete = "Mg" });
                barS.DataPoints.Add(new PonDataPoint() { Value = (double)item.s.GetValueOrDefault(), Label = item.s.GetValueOrDefault().ToString("N0"), Category = "S", CategoryComplete = "S" });
                barCTC.DataPoints.Add(new PonDataPoint() { Value = (double)item.ctc, Label = item.ctc.ToString("N0"), Category = "CTC", CategoryComplete = "CTC" });
                barMGCTC.DataPoints.Add(new PonDataPoint() { Value = (double)item.mg_ctc, Label = item.mg_ctc.ToString("N0"), Category = "Mg%", CategoryComplete = "Mg%" });
                barCACTC.DataPoints.Add(new PonDataPoint() { Value = (double)item.ca_ctc, Label = item.ca_ctc.ToString("N0"), Category = "Ca%", CategoryComplete = "Ca%" });
                barKCTC.DataPoints.Add(new PonDataPoint() { Value = (double)item.k_ctc, Label = item.k_ctc.ToString("N0"), Category = "K%", CategoryComplete = "K%" });
                barV.DataPoints.Add(new PonDataPoint() { Value = (double)item.v, Label = item.v.ToString("N0"), Category = "V%", CategoryComplete = "V%" });
                barMO.DataPoints.Add(new PonDataPoint() { Value = (double)item.mo.GetValueOrDefault(), Label = item.mo.GetValueOrDefault().ToString("N0"), Category = "M.O.", CategoryComplete = "M.O." });
                barZN.DataPoints.Add(new PonDataPoint() { Value = (double)item.zn.GetValueOrDefault(), Label = item.zn.GetValueOrDefault().ToString("N0"), Category = "Zn", CategoryComplete = "Zn" });
                barFE.DataPoints.Add(new PonDataPoint() { Value = (double)item.fe.GetValueOrDefault(), Label = item.fe.GetValueOrDefault().ToString("N0"), Category = "Fe", CategoryComplete = "Fe" });
                barMN.DataPoints.Add(new PonDataPoint() { Value = (double)item.mn.GetValueOrDefault(), Label = item.mn.GetValueOrDefault().ToString("N0"), Category = "Mn", CategoryComplete = "Mn" });
                barCU.DataPoints.Add(new PonDataPoint() { Value = (double)item.cu.GetValueOrDefault(), Label = item.cu.GetValueOrDefault().ToString("N0"), Category = "Cu", CategoryComplete = "Cu" });
                barB.DataPoints.Add(new PonDataPoint() { Value = (double)item.b.GetValueOrDefault(), Label = item.b.GetValueOrDefault().ToString("N0"), Category = "B", CategoryComplete = "B" });
                barAL.DataPoints.Add(new PonDataPoint() { Value = (double)item.al.GetValueOrDefault(), Label = item.al.GetValueOrDefault().ToString("N0"), Category = "Al", CategoryComplete = "Al" });
                barHAL.DataPoints.Add(new PonDataPoint() { Value = (double)item.h_al.GetValueOrDefault(), Label = item.h_al.GetValueOrDefault().ToString("N0"), Category = "H+Al", CategoryComplete = "H+Al" });

                chart.Series.Add(barPH);
                chart.Series.Add(barP);
                chart.Series.Add(barK);
                chart.Series.Add(barCA);
                chart.Series.Add(barMG);
                chart.Series.Add(barS);
                chart.Series.Add(barCTC);
                chart.Series.Add(barMGCTC);
                chart.Series.Add(barCACTC);
                chart.Series.Add(barKCTC);
                chart.Series.Add(barV);
                chart.Series.Add(barMO);
                chart.Series.Add(barZN);
                chart.Series.Add(barFE);
                chart.Series.Add(barMN);
                chart.Series.Add(barCU);
                chart.Series.Add(barB);
                chart.Series.Add(barAL);
                chart.Series.Add(barHAL);
            }
        }
        #endregion
    }
}