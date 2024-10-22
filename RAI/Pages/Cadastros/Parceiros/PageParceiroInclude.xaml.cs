using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using RAI.ViewModel;
using RAI.Controls;
using System.Linq;
using RAI.API;
using System;

namespace RAI.Pages.Cadastros.Parceiros
{
    public partial class PageParceiroInclude : WindowBase
    {
        public Parceiro parceiro { get; set; }

        public List<Estado> estados { get; set; }
        public List<Cidade> cidades { get; set; }
       
        public PageParceiroInclude()
        {
            InitializeComponent();
        }

        private async void WindowBase_Loaded(object sender, RoutedEventArgs e)
        {
            txtCnpjCpf.Focus();

            btGravar.IsLoading(true);

            if (estados == null) estados = await CadastroAPI.GetEstadosAsync();
            cbEstados.ItemsSource = estados;

            if (parceiro != null)
            {
                txtCodigo.Text = parceiro.codigo_parceiro == null ? "" : parceiro.codigo_parceiro;
                txtParceiro.Text = parceiro.nome;
                txtFantasia.Text = parceiro.fantasia;
                txtCelular.Text = parceiro.celular;
                txtCnpjCpf.Text = parceiro.cpf_cnpj;
                txtEmail.Text = parceiro.email;

                txtCep.Text = parceiro.cep;
                txtEndereco.Text = parceiro.endereco;
                txtNumero.Text = parceiro.numero;
                txtBairro.Text = parceiro.bairro;

                optInativo.IsChecked = parceiro.inativo;

                cbEstados.SelectedValue = parceiro.estado_id;
                cbCidades.SelectedValue = parceiro.cidade_id;
            }
            else
            {
                parceiro = new Parceiro();
                txtCnpjCpf.Focus();
            }

            btGravar.IsLoading(false);
        }

        private async void txtCnpjCpf_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCnpjCpf.Text.Trim().Length == 14 && parceiro.id == 0)
            {
                try
                {
                    btGravar.IsLoading(true);

                    var cpnjProprietario = await CadastroAPI.GetProprietariosCNPJAsync(txtCnpjCpf.Text.Trim());

                    if (cpnjProprietario != null)
                    {
                        txtParceiro.Text = cpnjProprietario.razao_social;
                        txtCep.Text = cpnjProprietario.endereco.cep;
                        txtNumero.Text = cpnjProprietario.endereco.numero;
                        txtCep_LostFocus(null, null);
                    }
                    else
                    {
                        Helper.ShowPonDialog("Empresa não localizada...");
                    }

                    btGravar.IsLoading(false);
                }
                catch (Exception)
                {
                    btGravar.IsLoading(false);
                }
            }
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtParceiro.Text.Trim().Length == 0)
            {
                txtParceiro.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(txtEmail.Text) && !txtEmail.Text.IsValidEmail())
            {
                txtEmail.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(txtCnpjCpf.Text) && !txtCnpjCpf.Text.IsValidCpfCnpj())
            {
                txtCnpjCpf.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(txtCep.Text) && txtCep.Text.Trim().Length != 8)
            {
                txtCep.Focus();
                return;
            }

            try
            {
                btGravar.IsLoading(true);

                parceiro.fornecedor = true;
                parceiro.cliente = false;
                parceiro.codigo_parceiro = txtCodigo.Text.Trim();
                parceiro.nome = txtParceiro.Text.Trim();
                parceiro.fantasia = txtFantasia.Text.Trim();
                parceiro.celular = txtCelular.Text.GetValueOrNull();
                parceiro.cpf_cnpj = txtCnpjCpf.Text.GetValueOrNull();
                parceiro.email = txtEmail.Text.GetValueOrNull();

                parceiro.cep = txtCep.Text;
                parceiro.endereco = txtEndereco.Text;
                parceiro.numero = txtNumero.Text;
                parceiro.bairro = txtBairro.Text;
                parceiro.cidade_id = cbCidades.SelectedValue.GetValueOrNull();
                parceiro.inativo = optInativo.IsChecked.Value;

                if (parceiro.id == 0)
                    parceiro = await CadastroAPI.PostParceiroAsync(parceiro);
                else
                    await CadastroAPI.PutParceiroAsync(parceiro);

                parceiro.cidade = cbCidades.Text + "-" + cbEstados.Text;
                parceiro.estado_id = cbEstados.SelectedValue.GetValueOrNull();

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