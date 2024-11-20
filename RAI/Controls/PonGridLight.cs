using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Controls;
using System.Windows.Controls;
using System.Windows;

namespace RAI.Controls
{
    public class PonGridLight : RadGridView
    {
        private bool PV { get; set; } = true;

        public PonGridLight()
        {
            ShowColumnSortIndexes = true;

            CanUserReorderColumns = false;
            CanUserSortColumns = false;
            IsFilteringAllowed = false;
            IsReadOnly = false;
            EnableMouseWheelScaling = false;
            ShowSearchPanel = false;
            CanUserFreezeColumns = false;
            AutoGenerateColumns = false;
            ShowGroupPanel = false;

            ColumnAggregatesAlignment = ColumnAggregatesAlignment.NextToGroupKey;
            GroupRenderMode = GroupRenderMode.Flat;
            FrozenColumnsSplitterVisibility = Visibility.Collapsed;
            RowIndicatorVisibility = Visibility.Collapsed;
            VerticalAlignment = VerticalAlignment.Top;
            ClipboardCopyMode = GridViewClipboardCopyMode.All;

            StyleManager.SetTheme(this, new FluentTheme());

            this.Loaded += PonGrid_Loaded;
        }

        private void PonGrid_Loaded(object sender, RoutedEventArgs e)
        {
            if (PV)
            {
                PV = false;

                foreach (var item in this.Columns)
                {
                    if (this.IsReadOnly) continue;
                    if (item.IsReadOnly) continue;
                    if (item.Header == null) continue;
                    if (!(item.Header is string)) continue;

                    var text_block = new TextBlock();
                    text_block.Text = item.Header.ToString();
                    text_block.FontStyle = FontStyles.Italic;
                    text_block.TextDecorations = TextDecorations.Underline;
                    text_block.TextWrapping = item.HeaderTextWrapping;
                    text_block.TextAlignment = item.HeaderTextAlignment;
                    text_block.ToolTip = "Coluna Editável";

                    item.Header = text_block;
                    item.ToolTip = "Coluna Editável";
                }
            }
        }
    }
}