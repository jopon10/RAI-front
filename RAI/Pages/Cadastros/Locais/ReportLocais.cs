using System.Collections.Generic;
using RAI.ViewModel;

namespace RAI.Pages.Cadastros.Locais
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