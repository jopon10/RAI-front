using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using RAI.ViewModel;
using System.Linq;
using RAI.API;
using System;

namespace RAI.Pages.Cadastros.Parceiros
{
    public partial class PageParceiros : UserControl
    {
        private List<Parceiro> parceiros_inativos { get; set; }
        private List<Parceiro> parceiros_ativos { get; set; }

        private bool inativos = false;

        public PageParceiros()
        {
            InitializeComponent();
        }

        private async void CarregaParceiros()
        {
            pb.Visibility = Visibility.Visible;

            if (inativos)
            {
                if (parceiros_inativos == null)
                    parceiros_inativos = await CadastroAPI.GetParceirosAsync(somenteInativos: true);

                grid.ItemsSource = parceiros_inativos.OrderBy(x => x.nome);
            }
            else
            {
                if (parceiros_ativos == null)
                    parceiros_ativos = await CadastroAPI.GetParceirosAsync();

                grid.ItemsSource = parceiros_ativos.OrderBy(x => x.nome);
            }

            pb.Visibility = Visibility.Hidden;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            parceiros_inativos = null;
            parceiros_ativos = null;

            CarregaParceiros();
        }

        private void btInativos_Click(object sender, RoutedEventArgs e)
        {
            inativos = !inativos;

            if (inativos)
                btInativos.Content = "Parceiros Ativos";
            else
                btInativos.Content = "Parceiros Inativos";

            CarregaParceiros();
        }

        private void btNovo_Click(object sender, RoutedEventArgs e)
        {
            ret.Visibility = Visibility.Visible;

            var window = new PageParceiroInclude();
            window.ShowDialog();

            if (window.gravou)
            {
                if (window.parceiro.inativo)
                {
                    if (parceiros_inativos != null) parceiros_inativos.Add(window.parceiro);
                }
                else
                    parceiros_ativos.Add(window.parceiro);

                grid.Rebind();
                Helper.ShowSnack(snack, "Incluído com sucesso");
            }

            ret.Visibility = Visibility.Collapsed;
        }

        private void ButtonColumnEdit_CustomClick(object sender, RoutedEventArgs e)
        {
            if (sender == null) return;

            ret.Visibility = Visibility.Visible;

            var parceiro = sender as Parceiro;
            grid.SelectedItem = parceiro;

            var window = new PageParceiroInclude();
            window.parceiro = parceiro;
            window.ShowDialog();

            if (window.gravou)
            {
                if (window.parceiro.inativo != inativos)
                {
                    if (inativos)
                    {
                        parceiros_inativos.Remove(parceiro);
                        parceiros_ativos.Add(parceiro);
                    }
                    else
                    {
                        parceiros_ativos.Remove(parceiro);
                        if (parceiros_inativos != null) parceiros_inativos.Add(parceiro);
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

            var parceiro = sender as Parceiro;

            try
            {
                await CadastroAPI.DeleteParceiroAsync(parceiro.id);

                if (inativos)
                    parceiros_inativos.Remove(parceiro);
                else
                    parceiros_ativos.Remove(parceiro);

                grid.Rebind();
                Helper.ShowSnack(snack, "Excluído com sucesso");
            }
            catch (Exception ex)
            {
                //LogError.GenerateLog(parceiro, this.Name);
                Helper.ShowPonDialog(ex.Message, tipoMensagem: MessageBoxImage.Exclamation);
            }
        }

        private void btImprimir_Click(object sender, RoutedEventArgs e)
        {
            //pb.Visibility = Visibility.Visible;

            //var consultaFiltro = new List<ViewModel.Parceiro>();

            //foreach (ViewModel.Parceiro item in grid.Items)
            //{
            //    consultaFiltro.Add(item);
            //}

            //pb.Visibility = Visibility.Hidden;

            //if (consultaFiltro == null || consultaFiltro.Count == 0)
            //{
            //    MessageBox.Show("Não foi localizado nenhum Parceiro!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            //    return;
            //}

            //var instance = new Telerik.Reporting.InstanceReportSource();

            //var report = new ReportParceiros(consultaFiltro);
            //report.nomeiaTitulo("Listagem de Parceiros");
            //report.nomeiaSubTitulo("");

            //instance.ReportDocument = report;

            //var window = new ReportViewer(instance);
            //window.Show();
        }
    }
}
