using MaterialDesignThemes.Wpf;
using System.Windows.Media;
using System.Windows;

namespace RAI.Controls
{
    public partial class PonDialog : WindowBase
    {
        private string _mensagem { get; set; }
        private string _titulo { get; set; }

        private bool _confirmacao { get; set; }
        private bool _simNao { get; set; }
        private bool _ok { get; set; } = true;

        private string _mensagemTable { get; set; }

        private PackIconKind _icone { get; set; }

        public PonDialog(string mensagem, string titulo = "Aviso", bool confirmacao = false, bool ok = false, bool simNao = false, MessageBoxImage tipoMensagem = MessageBoxImage.Information, string mensagemTable = "")
        {
            InitializeComponent();

            _mensagem = mensagem;
            _titulo = titulo;
            _confirmacao = confirmacao;
            _ok = ok;
            _simNao = simNao;
            _ok = ok;
            _mensagemTable = mensagemTable;

            switch (tipoMensagem)
            {
                case MessageBoxImage.Question:
                    _icone = PackIconKind.HelpRhombus;
                    break;
                case MessageBoxImage.Exclamation:
                    _icone = PackIconKind.Alert;
                    break;
                case MessageBoxImage.Error:
                    _icone = PackIconKind.CloseOctagon;
                    break;
                default:
                    _icone = PackIconKind.AlertCircle;
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtMensagem.Text = _mensagem;
            txtTitulo.Text = _titulo;

            if (!string.IsNullOrEmpty(_mensagemTable))
            {
                var linhas = _mensagemTable.Split('|');
                var strCol1 = "\n";
                var strCol2 = "\n";

                foreach (var linha in linhas)
                {
                    var coluna = linha.Split(':');
                    strCol1 += $"{coluna[0]}:  \n";
                    strCol2 += $"{coluna[1]}\n";
                }

                txtMensagemTableCol1.Text = strCol1;
                txtMensagemTableCol2.Text = strCol2;

                txtMensagemTableCol1.Visibility = Visibility.Visible;
                txtMensagemTableCol2.Visibility = Visibility.Visible;
            }

            if (_ok)
            {
                btOk.Visibility = Visibility.Visible;
                btOk.Focus();
            }

            if (_confirmacao)
            {
                optConfirmacao.IsChecked = false;
                stackConfirmacao.Visibility = Visibility.Visible;
                optConfirmacao.Focus();
            }

            if (_simNao)
            {
                btNao.Visibility = Visibility.Visible;
                btSim.Visibility = Visibility.Visible;
                btSim.Focus();
            }

            switch (_icone)
            {
                case PackIconKind.HelpRhombus:
                    icon.Foreground = Brushes.RoyalBlue;
                    break;
                case PackIconKind.Alert:
                    icon.Foreground = Brushes.Gold;
                    break;
                case PackIconKind.CloseOctagon:
                    icon.Foreground = Brushes.IndianRed;
                    break;
                case PackIconKind.AlertCircle:
                    icon.Foreground = Brushes.RoyalBlue;
                    break;
            }

            icon.Kind = _icone;
        }

        private void ColorZone_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btFechar_Click(object sender, RoutedEventArgs e)
        {
            gravou = false;
            Close();
        }

        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            gravou = true;
            Close();
        }

        private void btNao_Click(object sender, RoutedEventArgs e)
        {
            gravou = false;
            Close();
        }
    }
}