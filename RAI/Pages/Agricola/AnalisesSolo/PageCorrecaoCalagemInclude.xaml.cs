using System.Windows.Controls;
using System.Windows;
using RAI.ViewModel;
using RAI.Controls;
using RAI.API;
using System;

namespace RAI.Pages.Agricola.AnalisesSolo
{
    public partial class PageCorrecaoCalagemInclude : WindowBase
    {
        public AnaliseSolo analise { get; set; }

        public PageCorrecaoCalagemInclude()
        {
            InitializeComponent();
        }

        private void WindowBase_Loaded(object sender, RoutedEventArgs e)
        {
            btGravar.IsLoading(true);

            txtPRNT.TextChanged += CalculoNC;
            cbProfundidade.SelectionChanged += cbProfundidade_SelectionChanged;
            txtArea.TextChanged += txtArea_TextChanged;

            txtData.Text = analise.data.ToShortDateString();
            txtLocal.Text = analise.local;
            txtQuadra.Text = analise.quadra;

            txtCa.Text = analise.ca_ctc.ToString("N2");
            txtMg.Text = analise.mg_ctc.ToString("N2");
            txtK.Text = analise.k_ctc.ToString("N2");

            txtSB.Text = analise.sb.ToString("N2");
            txtCTC.Text = analise.ctc.ToString("N2");
            txtV.Text = analise.v.ToString("N2");

            if (analise.prnt != null) txtPRNT.Text = analise.prnt.GetValueOrDefault().ToString("N2");
            cbProfundidade.Text = analise.profundidade_incorporacao;
            if (analise.area != null) txtArea.Text = analise.area.GetValueOrDefault().ToString("N2");

            btGravar.IsLoading(false);
        }

        private void CalculoDC()
        {
            if (cbProfundidade.SelectedItem == null) return;
            if (txtArea.Text.Trim().Length == 0 || !txtArea.Text.IsNumeric()) return;
            if (txtNC.Text.Trim().Length == 0 || !txtNC.Text.IsNumeric()) return;

            decimal profundidade = 0;
            switch (cbProfundidade.Text)
            {
                case "Superficial":
                    profundidade = 0.5M;
                    break;
                case "20 cm":
                    profundidade = 1;
                    break;
                case "30 cm":
                    profundidade = 1.5M;
                    break;
                case "40 cm":
                    profundidade = 2;
                    break;
                case "60 cm":
                    profundidade = 3;
                    break;
                default:
                    break;
            }

            txtDC.Text = (txtNC.Text.ToDecimal().GetValueOrDefault() * profundidade * txtArea.Text.ToDecimal().GetValueOrDefault()).ToString("N2");
        }

        private void CalculoNC(object sender, TextChangedEventArgs e)
        {
            if (txtPRNT.Text.Trim().Length == 0 || !txtPRNT.Text.IsNumeric()) return;

            var prnt = txtPRNT.Text.ToDecimal().GetValueOrDefault();

            txtNC.Text = prnt > 0 ? $"{((analise.vd - analise.v) * analise.ctc / txtPRNT.Text.ToDecimal().GetValueOrDefault()).ToString("N2")} ton/ha" : "";

            CalculoDC();
        }

        private void cbProfundidade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculoDC();
        }

        private void txtArea_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculoDC();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btGravar.IsLoading(true);

                analise.prnt = txtPRNT.Text.ToDecimal();
                analise.profundidade_incorporacao = cbProfundidade.Text;
                analise.area = txtArea.Text.ToDecimal();

                await AgricolaAPI.PutAnaliseSoloCalagemAsync(analise);

                gravou = true;
                Close();
            }
            catch (Exception ex)
            {
                Helper.ShowPonDialog(ex.Message, tipoMensagem: MessageBoxImage.Exclamation);
                btGravar.IsLoading(false);
            }
        }
    }
}