using Telerik.Windows.Controls.Map;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Newtonsoft.Json;
using System.Windows;
using RAI.ViewModel;
using RAI.Controls;
using System.Linq;
using RAI.API;
using System;

namespace RAI.Pages.Locais
{
    public partial class PageLocalMapeamento : WindowBase
    {
        public Local local { get; set; }
        public Fazenda fazenda { get; set; }

        private MapPolyline polyline { get; set; }

        public PageLocalMapeamento()
        {
            InitializeComponent();

            this.WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.SingleBorderWindow;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btGravar.IsLoading(true);

            if (fazenda != null)
            {
                btGravar.Visibility = Visibility.Collapsed;

                fazenda = await CadastroAPI.GetFazendaMapaAsync(fazenda);
                txtLocal.Text = $"{fazenda.nome} - {fazenda.locais.Sum(x => x.hectares.GetValueOrDefault()).ToString("N2")} hectares mapeados";

                if (fazenda.locais.Count > 0)
                {
                    foreach (var item in fazenda.locais)
                    {
                        var newTextBlock = new FrameworkElementFactory(typeof(TextBlock));
                        newTextBlock.SetValue(TextBlock.TextProperty, item.nome_mapa);
                        newTextBlock.SetValue(TextBlock.ForegroundProperty, Brushes.White);
                        newTextBlock.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
                        newTextBlock.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                        newTextBlock.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);
                        DataTemplate template = new DataTemplate() { VisualTree = newTextBlock };

                        polyline = new MapPolyline()
                        {
                            Points = new LocationCollection(),
                            Fill = new SolidColorBrush(Color.FromArgb(90, 0, 100, 0)),
                            Stroke = new SolidColorBrush(Colors.Lime),
                            StrokeThickness = 2,
                            DataContext = item,
                            ToolTip = item.toolTip_mapa,
                            CaptionTemplate = template,
                        };

                        polyline.Points = JsonConvert.DeserializeObject<LocationCollection>(item.coordenadas);

                        polyline.CaptionLocation = polyline.GeoBounds.Center;

                        this.informationLayer.Items.Add(polyline);
                    }

                    SetBestView();
                }
                else
                {
                    BingRestSearchLocationRequest data = new BingRestSearchLocationRequest();
                    data.Query = fazenda.cidade;
                    this.restProvider.SearchLocationAsync(data);
                }
            }
            else
            {
                radMap.MapMouseClick += radMap_MapMouseClick;
                radMap.KeyDown += radMap_KeyDown;

                local = await CadastroAPI.GetLocalAsync(local);

                if (local == null)
                {
                    Helper.ShowPonDialog("Local não encontrado.");
                    return;
                }

                txtLocal.Text = local.nome;

                polyline = new MapPolyline()
                {
                    Points = new LocationCollection(),
                    Fill = new SolidColorBrush(Color.FromArgb(90, 0, 100, 0)),
                    Stroke = new SolidColorBrush(Colors.Lime),
                    StrokeThickness = 2
                };

                this.informationLayer.Items.Add(polyline);

                if (!string.IsNullOrEmpty(local.coordenadas))
                {
                    polyline.Points = JsonConvert.DeserializeObject<LocationCollection>(local.coordenadas);
                    SetBestView();
                }
                else
                {
                    BingRestSearchLocationRequest data = new BingRestSearchLocationRequest();
                    data.Query = local.cidade;
                    this.restProvider.SearchLocationAsync(data);
                }
            }

            btGravar.IsLoading(false);
        }

        private void radMap_MapMouseClick(object sender, MapMouseRoutedEventArgs eventArgs)
        {
            polyline.Points.Add(eventArgs.Location);
            polyline.ToolTip = polyline.Points.Count;
        }

        private void radMap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                e.Handled = true;

                if (polyline.Points.Count == 0) return;

                polyline.Points.Remove(polyline.Points[polyline.Points.Count - 1]);
                polyline.ToolTip = polyline.Points.Count;
            }
        }

        private void restProvider_SearchLocationCompleted(object sender, BingRestSearchLocationCompletedEventArgs e)
        {
            double[] bbox = e.Locations[0].BoundingBox;
            LocationRect rect = new LocationRect(new Location(bbox[2], bbox[1]), new Location(bbox[0], bbox[3]));
            this.radMap.SetView(rect);
        }

        private void SetBestView()
        {
            if (polyline != null && polyline.Points.Count > 0)
            {
                LocationRect rect = this.informationLayer.GetBestView(this.informationLayer.Items.Cast<object>());
                rect.MapControl = this.radMap;
                this.radMap.Center = rect.Center;
                this.radMap.ZoomLevel = rect.ZoomLevel;
            }
            else
            {
                BingRestSearchLocationRequest data = new BingRestSearchLocationRequest();
                data.Query = local != null ? local.cidade : fazenda.cidade;
                this.restProvider.SearchLocationAsync(data);
            }
        }

        private void btCentralizar_Click(object sender, RoutedEventArgs e)
        {
            SetBestView();
        }

        private async void btGravar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btGravar.IsLoading(true);

                var mapa = polyline.Points;

                var listPoints = new List<string>();

                foreach (var item in mapa)
                {
                    var lat = item.Latitude.ToString().Replace(",", ".");
                    var lng = item.Longitude.ToString().Replace(",", ".");

                    listPoints.Add(lat + ";" + lng);
                }

                if (polyline.Points.Count > 1)
                    local.coordenadas = JsonConvert.SerializeObject(listPoints);
                else
                    local.coordenadas = string.Empty;

                await CadastroAPI.PatchLocalCoordenadasAsync(local);

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