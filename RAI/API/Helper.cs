using System.Collections.Generic;
using MaterialDesignThemes.Wpf;
using System.Net.Http.Headers;
using System.Diagnostics;
using System.Net.Http;
using RAI.ViewModel;
using RAI.Controls;
using RAI.Pages;
using System;

namespace RAI.API
{
    public static class Helper
    {
        public static string BASE_URL = Debugger.IsAttached ? "http://127.0.0.1:3333/" : "https://pon7.herokuapp.com/";
        public static bool Demo { get => Debugger.IsAttached; }

        public static User user { get; set; }
        public static string Versao { get; set; } = "";
        public static string Token { get; set; } = "";
        public static string Empresa { get; set; } = "";
        public static int Login_id { get; set; }

        public static HttpClient getHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            return client;
        }

        public static void ShowSnack(Snackbar snack, string msg, double Milliseconds = 1000)
        {
            var myMessageQueue = new SnackbarMessageQueue(TimeSpan.FromMilliseconds(Milliseconds));
            snack.MessageQueue = myMessageQueue;
            snack.MessageQueue.Enqueue(msg);
        }

        public static bool ShowPonDialog(string mensagem, string titulo = "Aviso", bool confirmacao = false, bool ok = true, bool simNao = false, System.Windows.MessageBoxImage tipoMensagem = System.Windows.MessageBoxImage.Information, string mensagemTable = "")
        {
            if (simNao) ok = false;

            var dialog = new PonDialog(mensagem, titulo, confirmacao, ok, simNao, tipoMensagem, mensagemTable);
            dialog.ShowDialog();

            return dialog.gravou;
        }

        public static void ShowReport(Telerik.Reporting.Report report)
        {
            var instance = new Telerik.Reporting.InstanceReportSource() { ReportDocument = report };
            var window = new PageReportViewer(instance);
            window.Show();
        }

        public static void ShowReport(List<Telerik.Reporting.Report> reports)
        {
            Telerik.Reporting.InstanceReportSource instance;

            var reportBook = new Telerik.Reporting.ReportBook();
            foreach (var report in reports)
            {
                instance = new Telerik.Reporting.InstanceReportSource() { ReportDocument = report };
                reportBook.ReportSources.Add(instance);
            }

            instance = new Telerik.Reporting.InstanceReportSource { ReportDocument = reportBook };
            var window = new PageReportViewer(instance);
            window.Show();
        }

        public static void ShowReport(ReportBase report, string titulo = "", string subtitulo = "", bool ocultarDataHora = false, string documentName = "")
        {
            if (titulo.Trim().Length > 0) report.nomeiaTitulo(titulo);
            if (subtitulo.Trim().Length > 0) report.nomeiaSubTitulo(subtitulo);
            if (ocultarDataHora) report.ocultarDataHora();
            if (documentName.Trim().Length > 0) report.DocumentName = documentName;

            var instance = new Telerik.Reporting.InstanceReportSource() { ReportDocument = report };
            var window = new PageReportViewer(instance);
            window.Show();
        }

        public static void ShowReport(List<ReportBase> reports)
        {
            Telerik.Reporting.InstanceReportSource instance;

            var reportBook = new Telerik.Reporting.ReportBook();
            foreach (var report in reports)
            {
                instance = new Telerik.Reporting.InstanceReportSource() { ReportDocument = report };
                reportBook.ReportSources.Add(instance);
            }

            instance = new Telerik.Reporting.InstanceReportSource { ReportDocument = reportBook };
            var window = new PageReportViewer(instance);
            window.Show();
        }

        public static List<T> GetItemsGrid<T>(Telerik.Windows.Controls.RadGridView grid)
        {
            var lista = new List<T>();

            if ((grid != null || grid.Items != null) && grid.Items.Count > 0)
            {
                foreach (T item in grid.Items)
                {
                    lista.Add(item);
                }
            }

            return lista;
        }
    }
}