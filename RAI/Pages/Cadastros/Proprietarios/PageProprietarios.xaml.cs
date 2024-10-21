using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using RAI.ViewModel;
using RAI.API;
using System;

namespace RAI.Pages.Cadastros.Proprietarios
{
    public partial class PageProprietarios : UserControl
    {
        public List<Proprietario> proprietarios_ativos { get; set; }
        public List<Proprietario> proprietarios_inativos { get; set; }

        private bool inativos = false;

        public PageProprietarios()
        {
            InitializeComponent();
        }

        private async void Carrega()
        {
            pb.Visibility = Visibility.Visible;

            if (inativos)
            {
                if (proprietarios_inativos == null)
                    proprietarios_inativos = await CadastroAPI.GetProprietariosAsync(somenteInativos: true);

                grid.ItemsSource = proprietarios_inativos;
            }
            else
            {
                if (proprietarios_ativos == null)
                    proprietarios_ativos = await CadastroAPI.GetProprietariosAsync();

                grid.ItemsSource = proprietarios_ativos;
            }

            pb.Visibility = Visibility.Collapsed;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            proprietarios_ativos = null;
            proprietarios_inativos = null;
            Carrega();
        }

        private void btInativos_Click(object sender, RoutedEventArgs e)
        {
            inativos = !inativos;

            if (inativos)
                btInativos.Content = "Proprietários Ativos";
            else
                btInativos.Content = "Proprietários Inativos";

            Carrega();
        }

        private void btNovo_Click(object sender, RoutedEventArgs e)
        {
            ret.Visibility = Visibility.Visible;

            var window = new PageProprietarioInclude();
            window.ShowDialog();

            if (window.gravou)
            {
                if (window.proprietario.inativo)
                {
                    if (proprietarios_inativos != null) proprietarios_inativos.Add(window.proprietario);
                }
                else
                    proprietarios_ativos.Add(window.proprietario);

                grid.Rebind();
                Helper.ShowSnack(snack, "Incluído com sucesso");
            }

            ret.Visibility = Visibility.Collapsed;
        }

        private void ButtonEdit_CustomClick(object sender, RoutedEventArgs e)
        {
            if (sender == null) return;

            ret.Visibility = Visibility.Visible;

            var proprietario = sender as Proprietario;
            grid.SelectedItem = proprietario;

            var window = new PageProprietarioInclude();
            window.proprietario = proprietario;
            window.ShowDialog();

            if (window.gravou)
            {
                if (window.proprietario.inativo != inativos)
                {
                    if (inativos)
                    {
                        proprietarios_inativos.Remove(proprietario);
                        proprietarios_ativos.Add(proprietario);
                    }
                    else
                    {
                        proprietarios_ativos.Remove(proprietario);
                        if (proprietarios_inativos != null) proprietarios_inativos.Add(proprietario);
                    }
                }

                grid.Rebind();
                Helper.ShowSnack(snack, "Alterado com sucesso");
            }

            ret.Visibility = Visibility.Collapsed;
        }

        private async void ButtonDelete_DeleteClick(object sender, RoutedEventArgs e)
        {
            if (sender == null) return;

            var proprietario = sender as Proprietario;

            try
            {
                await CadastroAPI.DeleteProprietarioAsync(proprietario.id);

                if (inativos)
                    proprietarios_inativos.Remove(proprietario);
                else
                    proprietarios_ativos.Remove(proprietario);

                grid.Rebind();
                Helper.ShowSnack(snack, "Excluído com sucesso");
            }
            catch (Exception ex)
            {
                //LogError.GenerateLog(proprietario, this.Name);
                Helper.ShowPonDialog(ex.Message, tipoMensagem: MessageBoxImage.Exclamation);
            }
        }
    }
}