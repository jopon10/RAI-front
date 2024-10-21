using Telerik.Windows.Persistence.Services;
using System.Windows.Markup;
using System.Globalization;
using System.Threading;
using System.Windows;
using RAI.Controls;
using RAI.API;

namespace RAI
{
    public partial class App : Application
    {
        public App()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(
                        XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            ServiceProvider.RegisterPersistenceProvider<ICustomPropertyProvider>(typeof(PonGrid), new CustomPropProvider());
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            await LoginAPI.LogoutAsync();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //LogError.GenerateLog(e.Exception, "AppGlobal");

            Helper.ShowPonDialog("Não foi possível completar a operação.\nVerifique sua Conexão de Internet.\n" + e.Exception.Message, $"Aviso - Versão: {Helper.Versao}", tipoMensagem: MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
}