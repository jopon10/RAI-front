using Telerik.Windows.Controls.AutoSuggestBox;
using Microsoft.WindowsAPICodePack.Net;
using System.Collections.Generic;
using Telerik.Windows.Controls;
using System.Windows.Markup;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;
using System.Windows.Data;
using System.Reflection;
using RAI.Localization;
using System.Threading;
using Newtonsoft.Json;
using System.Windows;
using RAI.ViewModel;
using System.Linq;
using System.Net;
using System.IO;
using RAI.API;
using System;

namespace RAI.Pages
{
    public partial class PageLogin : Window
    {
        public List<Config> emails { get; set; }

        private string pathConfig = AppDomain.CurrentDomain.BaseDirectory + "//config.json";

        public PageLogin()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");

            this.Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);

            LocalizationManager.Manager = new CustomLocalizationManager();

            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
        }

        public bool FilterItem(object value)
        {
            return ((Config)value).UserEmail.ToLowerInvariant().Contains((txtEmail.Text ?? "").ToLowerInvariant());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();

            Helper.Versao = assembly.GetName().Version.ToString();
            var fileInfo = new FileInfo(assembly.Location);

            txtVersion.Text = $"Versão: {Helper.Versao} - {fileInfo.LastWriteTime.ToString("dd/MM HH:mm")}";

            if (File.Exists(pathConfig))
            {
                try
                {
                    emails = JsonConvert.DeserializeObject<List<Config>>(File.ReadAllText(pathConfig));
                }
                catch (Exception)
                {
                    var email = JsonConvert.DeserializeObject<Config>(File.ReadAllText(pathConfig));
                    emails = new List<Config>();
                    emails.Add(email);
                }

                var collectionView = CollectionViewSource.GetDefaultView(emails);
                collectionView.Filter = new Predicate<object>(FilterItem);
                txtEmail.ItemsSource = collectionView;
                txtEmail.Text = emails.FirstOrDefault().UserEmail;
                txtSenha.Focus();
            }

            if (emails == null) emails = new List<Config>();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtEmail.ItemsSource == null) return;

            if (e.Reason == TextChangeReason.UserInput)
            {
                var collectionView = (ICollectionView)txtEmail.ItemsSource;
                collectionView.Refresh();
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            btEntrar.IsEnabled = false;
            pb.Visibility = Visibility.Visible;

            var network_name = "";
            var networks = NetworkListManager.GetNetworks(NetworkConnectivityLevels.Connected).FirstOrDefault();
            if (networks != null)
                network_name = networks.Description;

            var login = new Login();
            login.computer_name = Environment.MachineName;
            login.app_version = Helper.Versao;
            login.domain_name = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
            login.user_windows_name = Environment.UserName;
            login.network_name = network_name;
            try
            {
                login.external_ip = IPAddress.Parse(new WebClient().DownloadString("https://ipinfo.io/ip")).ToString();
                login.local_ip = Dns.GetHostEntry(Dns.GetHostName())
                               .AddressList
                               .First(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                               .ToString();
            }
            catch (Exception)
            {
            }

            var user = new User
            {
                email = txtEmail.Text,
                password = txtSenha.Password,
                login = login
            };

            try
            {
                if (await LoginAPI.PostSessionAsync(user))
                {
                    var config = new Config
                    {
                        UserEmail = txtEmail.Text,
                        IdCliente = Helper.user.cliente_id
                    };

                    emails.RemoveAll(f => f.UserEmail == config.UserEmail);
                    emails.Insert(0, config);

                    File.WriteAllText(pathConfig, JsonConvert.SerializeObject(emails));

                    var window = new PageMenu();
                    window.Show();

                    this.Close();
                }
                else
                {
                    txtSenha.Focus();
                    Helper.ShowPonDialog("Email ou senha inválido.");
                }
            }
            catch (Exception ex)
            {
                Helper.ShowPonDialog(ex.Message, tipoMensagem: MessageBoxImage.Exclamation);
            }

            pb.Visibility = Visibility.Hidden;
            btEntrar.IsEnabled = true;
        }

        private void btFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ColorZone_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}