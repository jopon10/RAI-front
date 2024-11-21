using System.Collections.Generic;
using Telerik.Windows.Controls;
using RAI.ViewModel;
using System.Windows;
using System.Linq;
using RAI.API;
using System;

namespace RAI.Pages.Cadastros.Usuarios
{
    public partial class PageUsuarioInclude : Controls.WindowBase
    {
        public User user { get; set; }

        public PageUsuarioInclude()
        {
            InitializeComponent();
        }

        private void WindowBase_Loaded(object sender, RoutedEventArgs e)
        {
            btGravar.IsLoading(true);

            if (user != null)
            {
                txtNome.Text = user.nome;
                txtEmail.Text = user.email;
                optAdmin.IsChecked = user.admin;
                txtCelular.Text = user.celular;
                optInativo.IsChecked = user.inativo;

                if (user.admin) tabPermissoes.IsEnabled = false;
            }
            else
            {
                user = new User();
                txtNome.Focus();
            }

            var list = new List<Permissao>();
            //list.Add(new Permissao { grupo = "Cadastros", nome = "Proprietários" });
            list.Add(new Permissao { grupo = "Cadastros", nome = "Fazendas" });
            list.Add(new Permissao { grupo = "Cadastros", nome = "Talhões" });
            list.Add(new Permissao { grupo = "Cadastros", nome = "Laboratórios" });
            list.Add(new Permissao { grupo = "Cadastros", nome = "Usuários" });

            list.Add(new Permissao { grupo = "Agrícola", nome = "Análise de Solo" });

            var grupos = list.Select(f => f.grupo).Distinct();
            foreach (var grupo in grupos)
            {
                RadTreeViewItem parent = new RadTreeViewItem();
                parent.Header = grupo;
                tv.Items.Add(parent);

                foreach (var item in list.Where(f => f.grupo == grupo))
                {
                    RadTreeViewItem permissao = new RadTreeViewItem();
                    permissao.Header = item.nome;

                    if (user.id > 0)
                    {
                        //if (item.nome == "Proprietários") permissao.IsChecked = user.proprietarios;
                        if (item.nome == "Fazendas") permissao.IsChecked = user.fazendas;
                        if (item.nome == "Talhões") permissao.IsChecked = user.locais;
                        if (item.nome == "Laboratórios") permissao.IsChecked = user.parceiros;
                        if (item.nome == "Usuários") permissao.IsChecked = user.usuarios;

                        if (item.nome == "Análise de Solo") permissao.IsChecked = user.analise_solo;
                    }

                    parent.Items.Add(permissao);
                }
            }
           
            tv.UpdateLayout();

            btGravar.IsLoading(false);
        }

        private void optAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (optAdmin.IsChecked.Value)
                tabPermissoes.IsEnabled = false;
            else
                tabPermissoes.IsEnabled = true;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtNome.Text.Trim().Length == 0)
            {
                tabDadosBasicos.IsSelected = true;
                txtNome.Focus();
                return;
            }

            if (!txtEmail.Text.IsValidEmail())
            {
                tabDadosBasicos.IsSelected = true;
                txtEmail.Focus();
                return;
            }

            if (user.id == 0)
            {
                if (txtSenha.Password.Length < 4)
                {
                    tabDadosBasicos.IsSelected = true;
                    txtSenha.Focus();
                    return;
                }

                if (txtSenha.Password != txtSenhaConfirma.Password)
                {
                    tabDadosBasicos.IsSelected = true;
                    Helper.ShowPonDialog("Senhas não coincidem.");
                    txtSenha.Focus();
                    return;
                }
            }
            else
            {
                if (txtSenha.Password.Length > 0)
                {
                    if (txtSenha.Password.Length < 4)
                    {
                        tabDadosBasicos.IsSelected = true;
                        txtSenha.Focus();
                        return;
                    }

                    if (txtSenha.Password != txtSenhaConfirma.Password)
                    {
                        tabDadosBasicos.IsSelected = true;
                        Helper.ShowPonDialog("Senhas não coincidem.");
                        txtSenha.Focus();
                        return;
                    }
                }
            }

            try
            {
                btGravar.IsLoading(true);

                user.nome = txtNome.Text;
                user.email = txtEmail.Text;
                if (txtSenha.Password.Length > 0) user.password = txtSenha.Password;
                user.admin = optAdmin.IsChecked.Value;
                user.celular = txtCelular.Text;
                user.inativo = optInativo.IsChecked.Value;

                if (!user.admin)
                {
                    foreach (var item in tv.CheckedItems)
                    {
                        if (!(item is RadTreeViewItem)) continue;

                        var node = item as RadTreeViewItem;

                        bool pode = node.CheckState == System.Windows.Automation.ToggleState.On;

                        if (node.Parent != null)
                        {
                            //if (node.Header.ToString() == "Proprietários") user.proprietarios = pode;
                            if (node.Header.ToString() == "Fazendas") user.fazendas = pode;
                            if (node.Header.ToString() == "Talhões") user.locais = pode;
                            if (node.Header.ToString() == "Laboratórios") user.parceiros = pode;
                            if (node.Header.ToString() == "Usuários") user.usuarios = pode;

                            if (node.Header.ToString() == "Análise de Solo") user.analise_solo = pode;
                        }
                    }
                }

                if (user.id == 0)
                    user = await CadastroAPI.PostUserAsync(user);
                else
                    await CadastroAPI.PutUserAsync(user);

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