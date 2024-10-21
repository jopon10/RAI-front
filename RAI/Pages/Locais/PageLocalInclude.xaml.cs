using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using RAI.ViewModel;
using RAI.Controls;
using System.Linq;
using RAI.API;
using System;

namespace RAI.Pages.Locais
{
    public partial class PageLocalInclude : WindowBase
    {
        public Local local { get; set; }

        public List<Fazenda> fazendas { get; set; }
        public List<Cultura> culturas { get; set; }
        public List<Variedade> variedades { get; set; }

        public PageLocalInclude()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btGravar.IsLoading(true);

            fazendas = await CadastroAPI.GetFazendasAsync(minimal: true);
            culturas = await CadastroAPI.GetCulturasAsync();
            variedades = await CadastroAPI.GetVariedadesAsync();

            cbFazendas.ItemsSource = fazendas;
            cbCulturas.ItemsSource = culturas;

            if (local != null)
            {
                if (local.tipo_local != null) cbTipoLocal.SelectedIndex = (int)local.tipo_local;
                txtLocal.Text = local.nome;

                cbCulturas.SelectedValue = local.cultura_id;
                cbFazendas.SelectedValue = local.fazenda_id;
                cbVariedades.SelectedValue = local.variedade_id;

                txtEspacamentoLinha.Text = local.espacamento_linha == null ? "" : local.espacamento_linha.Value.ToString("N2");
                txtEspacamentoPlanta.Text = local.espacamento_planta == null ? "" : local.espacamento_planta.Value.ToString("N2");
                txtHectares.Text = local.hectares == null ? "" : local.hectares.Value.ToString("N2");
                txtPlantas.Text = local.plantas == null ? "" : local.plantas.Value.ToString("N0");

                d1.SelectedDate = local.data_plantio;
                optInativo.IsChecked = local.inativo;
            }
            else
            {
                local = new Local();
                cbTipoLocal.Focus();
            }

            btGravar.IsLoading(false);
        }

        private void cbTipoLocal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTipoLocal.SelectedIndex == 0)
            {
                gridLavoura.Visibility = Visibility.Visible;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(d1, "Data do Plantio");
            }
            else
            {
                gridLavoura.Visibility = Visibility.Collapsed;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(d1, "Data da Edificação");
            }
        }

        private void cbCulturas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCulturas.SelectedItem == null) return;

            var cultura = cbCulturas.SelectedItem as Cultura;
            cbVariedades.ItemsSource = variedades.Where(f => f.cultura_id == cultura.id).ToList();
        }

        private void txtEspacamentoLinha_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entreLinhas = txtEspacamentoLinha.Text.ToDecimal();
            var entrePlantas = txtEspacamentoPlanta.Text.ToDecimal();
            var hectares = txtHectares.Text.ToDecimal();

            if (entreLinhas.GetValueOrDefault() == 0) return;
            if (entrePlantas.GetValueOrDefault() == 0) return;
            if (hectares.GetValueOrDefault() == 0) return;

            var plantasHectare = 10000 / (entreLinhas * entrePlantas);

            txtPlantasHectare.Text = plantasHectare.GetValueOrDefault().ToString("N0");
            txtPlantas.Text = (plantasHectare * hectares).GetValueOrDefault().ToString("N0");
        }

        private void txtPlantas_TextChanged(object sender, TextChangedEventArgs e)
        {
            var plantas = txtPlantas.Text.ToDecimal();
            var hectares = txtHectares.Text.ToDecimal();

            if (plantas.GetValueOrDefault() == 0) return;
            if (hectares.GetValueOrDefault() == 0) return;

            txtPlantasHectare.Text = (plantas / hectares).GetValueOrDefault().ToString("N0");
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbTipoLocal.SelectedValue == null)
            {
                cbTipoLocal.Focus();
                return;
            }

            if (txtLocal.Text.Trim().Length == 0)
            {
                txtLocal.Focus();
                return;
            }

            if (cbFazendas.SelectedValue == null)
            {
                cbFazendas.Focus();
                return;
            }

            if (cbCulturas.SelectedValue == null)
            {
                cbCulturas.Focus();
                return;
            }

            if (cbVariedades.Text.Trim() != "" && cbVariedades.SelectedValue == null)
            {
                cbVariedades.Focus();
                return;
            }

            if (cbTipoLocal.SelectedIndex == 0)
            {
                if (txtHectares.Text != "" && !txtHectares.Text.IsNumeric())
                {
                    txtHectares.Focus();
                    return;
                }

                if (txtPlantas.Text != "" && !txtPlantas.Text.IsNumeric())
                {
                    txtPlantas.Focus();
                    return;
                }
            }

            try
            {
                btGravar.IsLoading(true);

                local.tipo_local = cbTipoLocal.SelectedIndex;
                local.nome = txtLocal.Text;
                local.codigo = "1";
                local.cultura_id = cbCulturas.SelectedValue.GetValueOrNull();
                local.fazenda_id = cbFazendas.SelectedValue.GetValueOrNull();
                local.variedade_id = cbVariedades.SelectedValue.GetValueOrNull();

                if (cbTipoLocal.SelectedIndex == 0)
                {
                    local.hectares = txtHectares.Text.ToDecimal();

                    local.plantas = txtPlantas.Text.ToIntOrNull();

                    if (txtEspacamentoLinha.Text.IsNumeric())
                        local.espacamento_linha = txtEspacamentoLinha.Text.ToDecimal();
                    else
                        local.espacamento_linha = null;

                    if (txtEspacamentoPlanta.Text.IsNumeric())
                        local.espacamento_planta = txtEspacamentoPlanta.Text.ToDecimal();
                    else
                        local.espacamento_planta = null;
                }
                else
                {
                    local.hectares = null;
                    local.plantas = null;
                    local.espacamento_linha = null;
                    local.espacamento_planta = null;
                }

                local.data_plantio = d1.SelectedDate;
                local.inativo = optInativo.IsChecked.Value;

                local.cultura = cbCulturas.Text;
                local.fazenda = cbFazendas.Text;
                local.variedade = cbVariedades.Text;

                if (local.plantas > 0 && local.hectares > 0)
                    local.plantas_hectare = local.plantas / local.hectares;

                if (local.id == 0)
                    local = await CadastroAPI.PostLocalAsync(local);
                else
                    await CadastroAPI.PutLocalAsync(local);

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