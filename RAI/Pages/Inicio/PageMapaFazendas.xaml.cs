using Telerik.Windows.Controls.Map;
using System.Collections.Generic;
using Telerik.Windows.Controls;
using System.Windows.Controls;
using System.Windows.Media;
using Newtonsoft.Json;
using System.Windows;
using RAI.ViewModel;
using System.Linq;
using RAI.API;

namespace RAI.Pages.Inicio
{
    public partial class PageMapaFazendas : UserControl
    {
        public List<Local> locais { get; set; }
        private MapPolyline polyline { get; set; }

        public PageMapaFazendas()
        {
            InitializeComponent();
        }

        private async void Atualizar()
        {
            pb.Visibility = Visibility.Visible;

            locais = await CadastroAPI.GetFazendasMapasAsync();
            tv.Items.Clear();

            var filtros = new List<Local>();
            if (locais.Where(x => x.fazenda_id != null).Count() > 0) filtros.AddRange(locais.Where(x => x.fazenda_id != null).GroupBy(x => x.fazenda_id.GetValueOrDefault()).Select(x => new Local { id = x.Key, nome = x.First().fazenda, tipo_filtro = "Fazenda" }).ToList());
            if (locais.Where(x => x.fazenda_id != null).Count() > 0) filtros.AddRange(locais.Where(x => x.cultura_id != null).GroupBy(x => x.cultura_id.GetValueOrDefault()).Select(x => new Local { id = x.Key, nome = x.First().cultura, tipo_filtro = "Cultura" }).ToList());
            if (locais.Where(x => x.variedade_id != null).Count() > 0) filtros.AddRange(locais.Where(x => x.variedade_id != null).GroupBy(x => x.variedade_id.GetValueOrDefault()).Select(x => new Local { id = x.Key, nome = x.First().variedade, tipo_filtro = "Variedade" }).ToList());

            var grupos = filtros.Select(f => f.tipo_filtro).Distinct();
            foreach (var grupo in grupos)
            {
                var parent = new RadTreeViewItem();
                parent.Header = grupo;
                tv.Items.Add(parent);

                foreach (var item in filtros.Where(f => f.tipo_filtro == grupo))
                {
                    var obj = new RadTreeViewItem();
                    obj.Header = item.nome;
                    obj.DataContext = item;
                    obj.IsChecked = true;
                    parent.Items.Add(obj);
                }
            }

            tv.Checked += tv_Checked;
            tv.Unchecked += tv_Checked;

            CarregaMapa();

            tv.UpdateLayout();

            pb.Visibility = Visibility.Collapsed;
        }

        private void CarregaMapa()
        {
            var fazendaIds = new List<int?>();
            var culturaIds = new List<int?>();
            var variedadeIds = new List<int?>();

            foreach (var item in tv.CheckedItems)
            {
                if (!(item is RadTreeViewItem)) continue;

                var node = item as RadTreeViewItem;

                bool pode = node.CheckState == System.Windows.Automation.ToggleState.On;

                if (pode)
                {
                    if (node.Parent.ToString() == "Fazenda") fazendaIds.Add((node.DataContext as Local).id);
                    if (node.Parent.ToString() == "Cultura") culturaIds.Add((node.DataContext as Local).id);
                    if (node.Parent.ToString() == "Variedade") variedadeIds.Add((node.DataContext as Local).id);
                }
            }

            polyline = null;
            this.informationLayer.Items.Clear();
            var locaisAux = locais.Where(x => fazendaIds.Contains(x.fazenda_id) && culturaIds.Contains(x.cultura_id)).ToList();

            if (locaisAux.Where(x => x.variedade_id != null).Count() > 0) locaisAux = locaisAux.Where(x => variedadeIds.Contains(x.variedade_id) || x.variedade_id is null).ToList();

            foreach (var item in locaisAux)
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

            txtTotalHa.Text = $"Hectares: {locaisAux.Sum(x => x.hectares.GetValueOrDefault()).ToString("N2")}";
            txtQtdeLocais.Text = $"Locais: {locaisAux.Count.ToString("N0")}";

            SetBestView();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (locais is null) Atualizar();
        }

        private void SetBestView()
        {
            LocationRect rect = this.informationLayer.GetBestView(this.informationLayer.Items.Cast<object>());
            rect.MapControl = this.radMap;
            this.radMap.Center = rect.Center;

            if (polyline != null && polyline.Points.Count > 0)
                this.radMap.ZoomLevel = rect.ZoomLevel;
            else
                this.radMap.ZoomLevel = rect.ZoomLevel + 1;
        }

        private void restProvider_SearchLocationCompleted(object sender, BingRestSearchLocationCompletedEventArgs e)
        {
            double[] bbox = e.Locations[0].BoundingBox;
            LocationRect rect = new LocationRect(new Location(bbox[2], bbox[1]), new Location(bbox[0], bbox[3]));
            this.radMap.SetView(rect);
        }

        private void tv_Checked(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            bool isInitiallyChecked = (e as RadTreeViewCheckEventArgs).IsUserInitiated;
            if (isInitiallyChecked) CarregaMapa();
        }

        private void btAtualizar_Click(object sender, RoutedEventArgs e)
        {
            Atualizar();
        }
    }
}