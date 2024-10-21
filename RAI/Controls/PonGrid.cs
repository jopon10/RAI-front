using Telerik.Windows.Persistence;
using Telerik.Windows.Controls;
using System.Linq;
using System.IO;
using System;

namespace RAI.Controls
{
    public class PonGrid : RadGridView
    {
        private bool PV { get; set; } = true;

        public PonGrid()
        {
            EnableMouseWheelScaling = true;
            ShowSearchPanel = true;
            IsReadOnly = true;
            ShowColumnSortIndexes = true;

            CanUserFreezeColumns = false;
            AutoGenerateColumns = false;
            ShowGroupPanel = false;

            ColumnAggregatesAlignment = Telerik.Windows.Controls.GridView.ColumnAggregatesAlignment.NextToGroupKey;
            GroupRenderMode = Telerik.Windows.Controls.GridView.GroupRenderMode.Flat;
            FrozenColumnsSplitterVisibility = System.Windows.Visibility.Collapsed;
            RowIndicatorVisibility = System.Windows.Visibility.Collapsed;
            VerticalAlignment = System.Windows.VerticalAlignment.Top;
            ClipboardCopyMode = GridViewClipboardCopyMode.All;

            StyleManager.SetTheme(this, new FluentTheme());
            GridViewContextMenu.SetIsEnabled(this, true);

            this.Loaded += PonGrid_Loaded;
        }

        private void PonGrid_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (PV)
            {
                PV = false;
                CarregarLayout();
            }
        }

        private void CarregarLayout()
        {
            var gridName = "";
            var pai = this.GetParents().FirstOrDefault(f => f.GetType().Namespace.Contains("P_ON.Pages"));
            if (pai != null) gridName = pai.GetType().FullName;

            string folder = $"{AppDomain.CurrentDomain.BaseDirectory}Layout\\";

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string path = $"{folder}{gridName}.layout";

            if (!File.Exists(path)) return;

            var fs = File.OpenRead(path);

            PersistenceManager manager = new PersistenceManager();
            fs.Position = 0L;
            manager.Load(this, fs);

            fs.Close();
            fs.Dispose();
        }
    }
}