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
            itemAreaTotal.Selected += ListBoxItem_Selected;
            itemAreaTotal.Unselected += ListBoxItem_Selected;
            itemFaixa.Selected += ListBoxItem_Selected;
            itemFaixa.Unselected += ListBoxItem_Selected;

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

            btGravar.IsLoading(false);
        }

        private void CalculoDC()
        {
            if (cbProfundidade.SelectedItem == null) return;
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

            txtDC.Text = (txtNC.Text.ToDecimal().GetValueOrDefault() * profundidade * (itemAreaTotal.IsSelected ? 1 : 0.5M)).ToString("N2");
        }

        private void CalculoNC(object sender, TextChangedEventArgs e)
        {
            if (txtPRNT.Text.Trim().Length == 0 || !txtPRNT.Text.IsNumeric()) return;

            var prnt = txtPRNT.Text.ToDecimal().GetValueOrDefault();

            txtNC.Text = prnt > 0 ? $"{((analise.vd - analise.v) * analise.ctc / txtPRNT.Text.ToDecimal().GetValueOrDefault()).ToString("N2")}" : "";

            CalculoDC();
        }

        private void cbProfundidade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculoDC();
        }

        private void item_Selected(object sender, RoutedEventArgs e)
        {
            CalculoDC();
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            if (sender == null) return;

            var item = sender as ListBoxItem;
            if (item.Name == "itemAreaTotal" && item.IsSelected)
                itemFaixa.IsSelected = false;
            else if (item.Name == "itemAreaTotal" && !item.IsSelected)
                itemFaixa.IsSelected = true;
            else if (item.Name == "itemFaixa" && item.IsSelected)
                itemAreaTotal.IsSelected = false;
            else if (item.Name == "itemFaixa" && !item.IsSelected)
                itemAreaTotal.IsSelected = true;

            CalculoDC();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btGravar.IsLoading(true);

                analise.prnt = txtPRNT.Text.ToDecimal();
                analise.profundidade_incorporacao = cbProfundidade.Text;
                //analise.area = txtArea.Text.ToDecimal();

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