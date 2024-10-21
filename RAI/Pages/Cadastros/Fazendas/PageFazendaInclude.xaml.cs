using System.Collections.Generic;
using System.Windows.Controls;
using RAI.ViewModel;
using System.Windows;
using RAI.Controls;
using System.Linq;
using RAI.API;
using System;

namespace RAI.Pages.Cadastros.Fazendas
{
    public partial class PageFazendaInclude : WindowBase
    {
        public Fazenda fazenda { get; set; }

        private List<Cultura> culturas { get; set; }
        private List<Estado> estados { get; set; }
        private List<Cidade> cidades { get; set; }

        public PageFazendaInclude()
        {
            InitializeComponent();
        }

        private async void WindowBase_Loaded(object sender, RoutedEventArgs e)
        {
            btGravar.IsLoading(true);

            estados = await CadastroAPI.GetEstadosAsync();
            cbEstados.ItemsSource = estados;

            culturas = await CadastroAPI.GetCulturasAsync();
            cbCulturas.ItemsSource = culturas;

            if (fazenda != null)
            {
                fazenda = await CadastroAPI.GetFazendaAsync(fazenda);

                txtNome.Text = fazenda.nome;
                txtCep.Text = fazenda.cep;
                txtEndereco.Text = fazenda.endereco;
                txtNumero.Text = fazenda.numero;
                txtBairro.Text = fazenda.bairro;
                cbEstados.SelectedValue = fazenda.estado_id;
                cbCidades.SelectedValue = fazenda.cidade_id;
                txtLatLong.Text = fazenda.lat_long;
                optInativa.IsChecked = fazenda.inativa;

                var culturasAux = fazenda.culturas.Select(x => x.id).ToList();
                if (culturasAux != null && culturasAux.Count > 0)
                {
                    foreach (Cultura item in cbCulturas.Items)
                    {
                        if (culturasAux.Contains(item.id))
                        {
                            cbCulturas.Text += $"{item.nome}, ";
                            item.selecionado = true;
                        }
                    }
                }
                cbCulturas.Text = cbCulturas.Text.ToString().Trim().TrimEnd(',');
            }
            else
            {
                fazenda = new Fazenda();
                txtNome.Focus();
            }

            btGravar.IsLoading(false);
        }

        private async void txtCep_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCep.Text.Trim().Length == 8)
            {
                try
                {
                    btGravar.IsLoading(true);

                    var endereco = await CadastroAPI.GetConsultaCepAsync(txtCep.Text);
                    if (endereco != null)
                    {
                        var estado = estados.FirstOrDefault(f => f.sigla == endereco.uf);

                        if (estado != null)
                        {
                            cbEstados.SelectionChanged -= cbEstados_SelectionChanged;
                            cbEstados.SelectedItem = estado;
                            cbEstados.SelectionChanged += cbEstados_SelectionChanged;

                            if (cidades == null)
                            {
                                cidades = await CadastroAPI.GetCidadesAsync(estado);
                                cbCidades.ItemsSource = cidades;
                            }

                            if (cidades.Where(x => x.estado_id == estado.id).Count() == 0)
                                cidades.AddRange(await CadastroAPI.GetCidadesAsync(estado));

                            cbCidades.ItemsSource = cidades.Where(x => x.estado_id == estado.id).ToList();
                            var cidade = cidades.FirstOrDefault(f => f.estado_id == estado.id && f.nome == endereco.nome_localidade);
                            cbCidades.SelectedItem = cidade;
                        }

                        if (endereco.bairro.Trim().Length > 0) txtBairro.Text = endereco.bairro;
                        if (endereco.endereco.Trim().Length > 0) txtEndereco.Text = endereco.endereco;

                        txtNumero.Focus();
                    }
                    else
                    {
                        Helper.ShowPonDialog("Cep não localizado...");
                    }

                    btGravar.IsLoading(false);
                }
                catch (Exception)
                {
                    btGravar.IsLoading(false);
                }
            }
        }

        private async void cbEstados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbEstados.SelectedItem == null)
            {
                cbCidades.ItemsSource = null;
                return;
            }
            else
            {
                var estado = cbEstados.SelectedItem as Estado;
                cidades = await CadastroAPI.GetCidadesAsync(estado);
                cbCidades.ItemsSource = cidades;
            }
        }

        private void check_Checked(object sender, RoutedEventArgs e)
        {
            cbCulturas.Text = "";

            foreach (Cultura item in cbCulturas.Items)
            {
                if (item.selecionado)
                    cbCulturas.Text += $"{item.nome}, ";
            }

            cbCulturas.Text = cbCulturas.Text.ToString().Trim().TrimEnd(',');
        }

        private void btPesquisarGoogle_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe", "www.google.com/maps");
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtNome.Text.Trim().Length == 0)
            {
                txtNome.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(txtCep.Text) && txtCep.Text.Trim().Length != 8)
            {
                txtCep.Focus();
                return;
            }

            if (cbEstados.SelectedItem == null)
            {
                cbEstados.Focus();
                return;
            }

            if (cbCidades.SelectedItem == null)
            {
                cbCidades.Focus();
                return;
            }

            try
            {
                btGravar.IsLoading(true);

                fazenda.nome = txtNome.Text;
                fazenda.inativa = optInativa.IsChecked.Value;

                fazenda.cep = txtCep.Text;
                fazenda.endereco = txtEndereco.Text;
                fazenda.numero = txtNumero.Text;
                fazenda.bairro = txtBairro.Text;

                fazenda.cidade_id = cbCidades.SelectedValue.ToInt();

                if (!string.IsNullOrEmpty(txtLatLong.Text))
                {
                    var latlong = txtLatLong.Text.Split(',');
                    fazenda.lat_long = latlong[0].Trim() + "," + latlong[1].Trim();
                }
                else
                    fazenda.lat_long = null;

                fazenda.culturas = new List<Cultura>();
                foreach (Cultura item in cbCulturas.Items)
                {
                    if (item.selecionado)
                        fazenda.culturas.Add(item);
                }

                if (fazenda.id == 0)
                    fazenda = await CadastroAPI.PostFazendasAsync(fazenda);
                else
                    fazenda = await CadastroAPI.PutFazendaAsync(fazenda);

                fazenda.cidade = cbCidades.Text;
                fazenda.estado = cbEstados.Text;

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