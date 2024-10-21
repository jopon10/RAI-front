namespace RAI.Pages
{
    partial class ReportBase
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.txtRodapeCentro = new Telerik.Reporting.TextBox();
            this.txtData = new Telerik.Reporting.TextBox();
            this.txtRodapeEsquerdo = new Telerik.Reporting.TextBox();
            this.txtTitulo = new Telerik.Reporting.TextBox();
            this.txtSubTitulo = new Telerik.Reporting.TextBox();
            this.txtEmpresa = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.Logo = new Telerik.Reporting.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.9D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.txtRodapeEsquerdo,
            this.txtData,
            this.txtRodapeCentro});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(2.2D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.Logo,
            this.textBox1,
            this.txtEmpresa,
            this.txtSubTitulo,
            this.txtTitulo});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // txtRodapeCentro
            // 
            this.txtRodapeCentro.Docking = Telerik.Reporting.DockingStyle.Fill;
            this.txtRodapeCentro.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.9D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.txtRodapeCentro.Name = "txtRodapeCentro";
            this.txtRodapeCentro.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.2D), Telerik.Reporting.Drawing.Unit.Cm(0.9D));
            this.txtRodapeCentro.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txtRodapeCentro.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txtRodapeCentro.Value = "rai.com";
            // 
            // txtData
            // 
            this.txtData.Docking = Telerik.Reporting.DockingStyle.Right;
            this.txtData.Format = "{0:g}";
            this.txtData.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.1D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.txtData.Name = "txtData";
            this.txtData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.9D), Telerik.Reporting.Drawing.Unit.Cm(0.9D));
            this.txtData.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.txtData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txtData.Value = "=Now()";
            // 
            // txtRodapeEsquerdo
            // 
            this.txtRodapeEsquerdo.Docking = Telerik.Reporting.DockingStyle.Left;
            this.txtRodapeEsquerdo.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.txtRodapeEsquerdo.Name = "txtRodapeEsquerdo";
            this.txtRodapeEsquerdo.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.9D), Telerik.Reporting.Drawing.Unit.Cm(0.9D));
            this.txtRodapeEsquerdo.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.txtRodapeEsquerdo.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txtRodapeEsquerdo.Value = "V1.0";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Docking = Telerik.Reporting.DockingStyle.Fill;
            this.txtTitulo.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.78D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.72D), Telerik.Reporting.Drawing.Unit.Cm(1D));
            this.txtTitulo.Style.Font.Bold = true;
            this.txtTitulo.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.txtTitulo.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txtTitulo.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txtTitulo.Value = "";
            // 
            // txtSubTitulo
            // 
            this.txtSubTitulo.Docking = Telerik.Reporting.DockingStyle.Bottom;
            this.txtSubTitulo.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.78D), Telerik.Reporting.Drawing.Unit.Cm(1.6D));
            this.txtSubTitulo.Name = "txtSubTitulo";
            this.txtSubTitulo.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.72D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.txtSubTitulo.Style.Font.Bold = true;
            this.txtSubTitulo.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.txtSubTitulo.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txtSubTitulo.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.txtSubTitulo.Value = "";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Docking = Telerik.Reporting.DockingStyle.Top;
            this.txtEmpresa.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.78D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(14.72D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.txtEmpresa.Style.Font.Bold = true;
            this.txtEmpresa.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.txtEmpresa.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txtEmpresa.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.txtEmpresa.Value = "";
            // 
            // textBox1
            // 
            this.textBox1.Docking = Telerik.Reporting.DockingStyle.Right;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(17.5D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.5D), Telerik.Reporting.Drawing.Unit.Cm(2.2D));
            this.textBox1.Value = "=\'Pag. \' + PageNumber + \' de \' + PageCount";
            // 
            // Logo
            // 
            this.Logo.Docking = Telerik.Reporting.DockingStyle.Left;
            this.Logo.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.Logo.Name = "Logo";
            this.Logo.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.78D), Telerik.Reporting.Drawing.Unit.Cm(2.2D));
            this.Logo.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch;
            this.Logo.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(10D);
            // 
            // ReportBase
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.pageFooterSection1});
            this.Name = "ReportBase";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(20D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.TextBox txtRodapeEsquerdo;
        private Telerik.Reporting.TextBox txtData;
        private Telerik.Reporting.TextBox txtRodapeCentro;
        private Telerik.Reporting.PictureBox Logo;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox txtEmpresa;
        private Telerik.Reporting.TextBox txtSubTitulo;
        private Telerik.Reporting.TextBox txtTitulo;
    }
}