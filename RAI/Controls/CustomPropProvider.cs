using Telerik.Windows.Persistence.Services;
using System.Collections.Generic;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;
using System.Linq;

namespace RAI.Controls
{
    public class CustomPropProvider : ICustomPropertyProvider
    {
        public CustomPropertyInfo[] GetCustomProperties()
        {
            // Create three custom properties to persist the Columns, Sorting and Group descriptors using proxy objects
            return new CustomPropertyInfo[]
            {
                new CustomPropertyInfo("Columns", typeof(List<ColumnProxy>)),
            };
        }

        public void InitializeObject(object context)
        {
            if (context is RadGridView)
            {
                RadGridView gridView = context as RadGridView;
                gridView.SortDescriptors.Clear();
                gridView.GroupDescriptors.Clear();
                gridView.Columns
                    .OfType<GridViewColumn>()
                    .Where(c => c.ColumnFilterDescriptor.IsActive)
                    .ToList().ForEach(c => c.ClearFilters());
            }
        }

        public object InitializeValue(CustomPropertyInfo customPropertyInfo, object context)
        {
            return null;
        }

        public object ProvideValue(CustomPropertyInfo customPropertyInfo, object context)
        {
            RadGridView gridView = context as RadGridView;

            switch (customPropertyInfo.Name)
            {
                case "Columns":
                    {
                        List<ColumnProxy> columnProxies = new List<ColumnProxy>();

                        foreach (GridViewColumn column in gridView.Columns)
                        {
                            if (string.IsNullOrEmpty(column.Header?.ToString())) continue;
                            if (!(column.Header is string)) continue;

                            columnProxies.Add(new ColumnProxy()
                            {
                                UniqueName = column.UniqueName ?? "",
                                Header = column.Header?.ToString(),
                                DisplayOrder = column.DisplayIndex,
                                Width = column.Width,
                                IsVisible = column.IsVisible,
                            });
                        }

                        return columnProxies;
                    }
            }

            return null;
        }

        public void RestoreValue(CustomPropertyInfo customPropertyInfo, object context, object value)
        {
            if (value == null) return;

            RadGridView gridView = context as RadGridView;

            switch (customPropertyInfo.Name)
            {
                case "Columns":
                    {
                        List<ColumnProxy> columnProxies = value as List<ColumnProxy>;

                        foreach (ColumnProxy proxy in columnProxies.OrderBy(x => x.DisplayOrder))
                        {
                            GridViewColumn column = null;
                            column = gridView.Columns[proxy.UniqueName];

                            if (column == null) continue;
                            if (proxy.DisplayOrder >= gridView.Columns.Count)
                                column.DisplayIndex = gridView.Columns.Count - 1;
                            else
                                column.DisplayIndex = proxy.DisplayOrder;

                            column.Header = proxy.Header;
                            column.Width = proxy.Width;
                            column.IsVisible = proxy.IsVisible;
                        }
                    }
                    break;
            }
        }
    }

    public class ColumnProxy
    {
        public string UniqueName { get; set; }
        public int DisplayOrder { get; set; }
        public string Header { get; set; }
        public GridViewLength Width { get; set; }
        public bool IsVisible { get; set; }
    }
}