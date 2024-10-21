using System.Collections.Generic;
using System.Windows.Controls;
using RAI.Pages.Locais;
using System.Windows;
using RAI.API;
using System;

namespace RAI.Pages.Cadastros.Fazendas
{
    public partial class PageFazendas : UserControl
    {
        public List<ViewModel.Fazenda> fazendas_ativas { get; set; }
        public List<ViewModel.Fazenda> fazendas_inativas { get; set; }

        private bool inativas = false;

        public PageFazendas()
        {
            InitializeComponent();
        }

        private async void Carrega()
        {
            pb.Visibility = Visibility.Visible;

            if (inativas)
            {
                if (fazendas_inativas == null)
                    fazendas_inativas = await CadastroAPI.GetFazendasAsync(somenteInativas: true);

                grid.ItemsSource = fazendas_inativas;
            }
            else
            {
                if (fazendas_ativas == null)
                    fazendas_ativas = await CadastroAPI.GetFazendasAsync();

                grid.ItemsSource = fazendas_ativas;
            }

            pb.Visibility = Visibility.Collapsed;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            fazendas_ativas = null;
            fazendas_inativas = null;
            Carrega();
        }

        private void btInativas_Click(object sender, RoutedEventArgs e)
        {
            inativas = !inativas;

            if (inativas)
                btInativas.Content = "Fazendas Ativas";
            else
                btInativas.Content = "Fazendas Inativas";

            Carrega();
        }

        private void btNovo_Click(object sender, RoutedEventArgs e)
        {
            ret.Visibility = Visibility.Visible;

            var window = new PageFazendaInclude();
            window.ShowDialog();

            if (window.gravou)
            {
                if (window.fazenda.inativa)
                {
                    if (fazendas_inativas != null) fazendas_inativas.Add(window.fazenda);
                }
                else
                    fazendas_ativas.Add(window.fazenda);

                grid.Rebind();
                Helper.ShowSnack(snack, "Incluído com sucesso");
            }

            ret.Visibility = Visibility.Collapsed;
        }

        private void ButtonColumnEdit_CustomClick(object sender, RoutedEventArgs e)
        {
            if (sender == null) return;

            ret.Visibility = Visibility.Visible;

            var fazenda = sender as ViewModel.Fazenda;
            grid.SelectedItem = fazenda;

            var window = new PageFazendaInclude();
            window.fazenda = fazenda;
            window.ShowDialog();

            if (window.gravou)
            {
                if (window.fazenda.inativa != inativas)
                {
                    if (inativas)
                    {
                        fazendas_inativas.Remove(fazenda);
                        fazendas_ativas.Add(fazenda);
                    }
                    else
                    {
                        fazendas_ativas.Remove(fazenda);
                        if (fazendas_inativas != null) fazendas_inativas.Add(fazenda);
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

            var fazenda = sender as ViewModel.Fazenda;

            try
            {
                await CadastroAPI.DeleteFazendaAsync(fazenda.id);

                if (inativas)
                    fazendas_inativas.Remove(fazenda);
                else
                    fazendas_ativas.Remove(fazenda);

                grid.Rebind();
                Helper.ShowSnack(snack, "Excluído com sucesso");
            }
            catch (Exception ex)
            {
                //LogError.GenerateLog(fazenda, this.Name);
                Helper.ShowPonDialog(ex.Message, tipoMensagem: MessageBoxImage.Exclamation);
            }
        }

        private void btMapa_CustomClick(object sender, RoutedEventArgs e)
        {
            if (sender == null) return;

            ret.Visibility = Visibility.Visible;

            var fazenda = sender as ViewModel.Fazenda;
            grid.SelectedItem = fazenda;

            var window = new PageLocalMapeamento();
            window.fazenda = fazenda;
            window.ShowDialog();

            ret.Visibility = Visibility.Collapsed;
        }
    }
}