using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using RAI.ViewModel;
using System.Linq;
using RAI.API;

namespace RAI.Pages.Cadastros.Usuarios
{
    public partial class PageUsuarios : UserControl
    {
        private List<User> usuarios_ativos { get; set; }
        private List<User> usuarios_inativos { get; set; }

        private bool inativos = false;

        public PageUsuarios()
        {
            InitializeComponent();
        }

        private async void CarregaUsuarios()
        {
            pb.Visibility = Visibility.Visible;

            if (inativos)
            {
                if (usuarios_inativos == null)
                    usuarios_inativos = await CadastroAPI.GetUsuariosAsync(true);

                grid.ItemsSource = usuarios_inativos.OrderBy(x => x.nome);
            }
            else
            {
                if (usuarios_ativos == null)
                    usuarios_ativos = await CadastroAPI.GetUsuariosAsync();

                grid.ItemsSource = usuarios_ativos.OrderBy(x => x.nome);
            }

            pb.Visibility = Visibility.Collapsed;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CarregaUsuarios();
        }

        private void btInativos_Click(object sender, RoutedEventArgs e)
        {
            inativos = !inativos;

            if (inativos)
                btInativos.Content = "Usuários Ativos";
            else
                btInativos.Content = "Usuários Inativos";

            CarregaUsuarios();
        }

        private void btNovo_Click(object sender, RoutedEventArgs e)
        {
            ret.Visibility = Visibility.Visible;

            var window = new PageUsuarioInclude();
            window.ShowDialog();

            if (window.gravou)
            {
                if (window.user.inativo)
                {
                    if (usuarios_inativos != null) usuarios_inativos.Add(window.user);
                }
                else
                    usuarios_ativos.Add(window.user);

                grid.Rebind();
                Helper.ShowSnack(snack, "Incluído com sucesso");
            }

            ret.Visibility = Visibility.Collapsed;
        }

        private void ButtonColumnEditUser_CustomClick(object sender, RoutedEventArgs e)
        {
            ret.Visibility = Visibility.Visible;

            if (sender == null) return;

            var user = sender as User;
            grid.SelectedItem = user;

            var window = new PageUsuarioInclude();
            window.user = user;
            window.ShowDialog();

            if (window.gravou)
            {
                if (window.user.inativo != inativos)
                {
                    if (inativos)
                    {
                        usuarios_inativos.Remove(user);
                        usuarios_ativos.Add(user);
                    }
                    else
                    {
                        usuarios_ativos.Remove(user);
                        if (usuarios_inativos != null) usuarios_inativos.Add(user);
                    }
                }

                grid.Rebind();
                Helper.ShowSnack(snack, "Alterado com sucesso");
            }

            ret.Visibility = Visibility.Collapsed;
        }
    }
}