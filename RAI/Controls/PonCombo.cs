using System.Windows.Controls;

namespace RAI.Controls
{
    public class PonCombo : ComboBox
    {
        public PonCombo()
        {
            StaysOpenOnEdit = true;
            IsEditable = true;
            IsTextSearchEnabled = false;
            //IsSynchronizedWithCurrentItem = true;

            this.MakeComboBoxSearchable();
        }
    }
}