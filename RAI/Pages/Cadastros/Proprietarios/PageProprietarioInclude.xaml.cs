using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using RAI.ViewModel;
using RAI.Controls;
using System.Linq;
using RAI.API;
using System;

namespace RAI.Pages.Cadastros.Proprietarios
{
    public partial class PageProprietarioInclude : WindowBase
    {
        public Proprietario proprietario { get; set; }

        private List<Estado> estados { get; set; }
        private List<Cidade> cidades { get; set; }

        public PageProprietarioInclude()
        {
            InitializeComponent();
        }

        private async void WindowBase_Loaded(object sender, RoutedEventArgs e)
        {
            btGravar.IsLoading(true);

            estados = await CadastroAPI.GetEstadosAsync();
            cbEstados.ItemsSource = estados;

            if (proprietario != null)
            {
                txtNome.Text = proprietario.nome;
                txtFantasia.Text = proprietario.fantasia;
                txtCnpjCpf.Text = proprietario.cpf_cnpj;
                txtCelular.Text = proprietario.celular;
                txtEmail.Text = proprietario.email;
                txtCep.Text = proprietario.cep;
                txtEndereco.Text = proprietario.endereco;
                txtNumero.Text = proprietario.numero;
                txtBairro.Text = proprietario.bairro;
                optInativo.IsChecked = proprietario.inativo;

                cbEstados.SelectedValue = proprietario.estado_id;
                cbCidades.SelectedValue = proprietario.cidade_id;
            }
            else
            {
                proprietario = new Proprietario();
                txtCnpjCpf.Focus();
            }

            btGravar.IsLoading(false);
        }

        private async void txtCnpjCpf_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCnpjCpf.Text.Trim().Length == 14 && proprietario.id == 0)
            {
                try
                {
                    btGravar.IsLoading(true);

                    var cpnjProprietario = await CadastroAPI.GetProprietariosCNPJAsync(txtCnpjCpf.Text.Trim());

                    if (cpnjProprietario != null)
                    {
                        txtNome.Text = cpnjProprietario.razao_social;
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
            if (txtNome.Text.Trim().Length == 0)
            {
                txtNome.Focus();
                return;
            }

            if (txtCnpjCpf.Text.Trim().Length == 0)
            {
                txtCnpjCpf.Focus();
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

                proprietario.nome = txtNome.Text.Trim();
                proprietario.fantasia = txtFantasia.Text.Trim();
                proprietario.cpf_cnpj = txtCnpjCpf.Text.Trim();
                proprietario.celular = txtCelular.Text.GetValueOrNull();
                proprietario.email = txtEmail.Text.GetValueOrNull();
                proprietario.cep = txtCep.Text;
                proprietario.endereco = txtEndereco.Text;
                proprietario.numero = txtNumero.Text;
                proprietario.bairro = txtBairro.Text;
                proprietario.inativo = optInativo.IsChecked.Value;

                if (cbCidades.SelectedItem != null)
                {
                    proprietario.cidade_id = (int)cbCidades.SelectedValue;
                    proprietario.estado_id = (int)cbEstados.SelectedValue;
                }
                else
                {
                    proprietario.cidade_id = null;
                    proprietario.estado_id = null;
                }

                if (proprietario.id == 0)
                    proprietario = await CadastroAPI.PostProprietarioAsync(proprietario);
                else
                    await CadastroAPI.PutProprietarioAsync(proprietario);

                proprietario.cidade = cbCidades.Text;
                proprietario.estado = cbEstados.Text;
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