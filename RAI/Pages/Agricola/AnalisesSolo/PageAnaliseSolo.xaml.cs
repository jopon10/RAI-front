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
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            pb.Visibility = Visibility.Visible;

            analises = await AgricolaAPI.GetAnalisesSoloAsync();
            grid.ItemsSource = analises;

            pb.Visibility = Visibility.Collapsed;
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
    }
}