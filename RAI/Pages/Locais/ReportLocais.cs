using System.Collections.Generic;
using RAI.ViewModel;

namespace RAI.Pages.Locais
{
    public partial class ReportLocais : ReportBase
    {
        public ReportLocais(List<Local> locais)
        {
            InitializeComponent();

            table1.DataSource = locais;
        }
    }
}