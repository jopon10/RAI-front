using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows;

namespace RAI.Controls
{
    public static class PonComboSearchable
    {
        public static void MakeComboBoxSearchable(this ComboBox targetComboBox)
        {
            targetComboBox.Loaded += TargetComboBox_Loaded;
        }

        private static void TargetComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var targetComboBox = sender as ComboBox;
            var targetTextBox = targetComboBox?.Template.FindName("PART_EditableTextBox", targetComboBox) as TextBox;

            if (targetTextBox == null) return;

            targetComboBox.Tag = "TextInput";
            targetComboBox.StaysOpenOnEdit = true;
            targetComboBox.IsEditable = true;
            targetComboBox.IsTextSearchEnabled = false;

            targetTextBox.TextChanged += (o, args) =>
            {
                var textBox = (TextBox)o;

                var searchText = textBox.Text;

                if (targetComboBox.Tag.ToString() == "Selection")
                {
                    targetComboBox.Tag = "TextInput";
                    //targetComboBox.IsDropDownOpen = true;
                }
                else
                {
                    if (targetComboBox.SelectionBoxItem != null)
                    {
                        targetComboBox.SelectedItem = null;
                        targetTextBox.Text = searchText;
                    }

                    if (string.IsNullOrEmpty(searchText))
                    {
                        targetComboBox.Items.Filter = item => true;
                        targetComboBox.SelectedItem = default(object);
                    }
                    else
                    {
                        if (targetComboBox.ItemsSource != null)
                        {
                            var collectionView = CollectionViewSource.GetDefaultView(targetComboBox.ItemsSource);
                            //collectionView.Filter = delegate (object s) { return ((Parceiro)s).nome.ToLowerInvariant().Contains((targetComboBox.Text ?? "").ToLowerInvariant()); };
                            collectionView.Filter = delegate (object s) { return (s.GetType().GetProperty(targetComboBox.DisplayMemberPath).GetValue(s, null).ToString().ToLowerInvariant().Contains((targetComboBox.Text ?? "").ToLowerInvariant())); };
                            targetComboBox.ItemsSource = collectionView;
                        }
                    }

                    Keyboard.ClearFocus();
                    Keyboard.Focus(targetTextBox);
                    targetComboBox.IsDropDownOpen = true;

                    textBox.SelectionStart = textBox.Text.Length;
                    textBox.SelectionLength = 0;
                }
            };

            targetComboBox.SelectionChanged += (o, args) =>
            {
                var comboBox = o as ComboBox;
                if (comboBox?.SelectedItem == null) return;
                comboBox.Tag = "Selection";
            };
        }
    }
}