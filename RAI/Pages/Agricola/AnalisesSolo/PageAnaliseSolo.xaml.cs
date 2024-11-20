using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using RAI.ViewModel;
using RAI.API;
using System;

namespace RAI.Pages.Agricola.AnalisesSolo
{
    public partial class PageAnaliseSolo : UserControl
    {
        public List<AnaliseSolo> analises { get; set; }

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
            CarregaAnalises();
        }

        private void dt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarregaAnalises();
        }

        private void btNovo_Click(object sender, RoutedEventArgs e)
        {
            ret.Visibility = Visibility.Visible;

            var window = new PageAnaliseSoloInclude();
            window.ShowDialog();

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
            window.ShowDialog();

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

            try
            {
                btFiltrar.IsLoading(true);

                var consulta = await AgricolaAPI.GetAnalisesSoloAsync(d1.SelectedDate.Value, d2.SelectedDate.Value);
                gridConsulta.ItemsSource = consulta;

                if (consulta.Count == 0) Helper.ShowSnack(snack, "Nenhuma informação encontrada no período!");
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
    }
}