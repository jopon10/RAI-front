using Telerik.Reporting.Drawing;
using Telerik.Reporting;
using System.Drawing;
using RAI.API;
using System;

namespace RAI.Pages
{
    public partial class ReportBase : Report
    {
        private Color BorderColor { get; set; }
        private BorderType BorderStyle { get; set; }
        private Unit BorderWidth { get; set; }
        private Color LineColor { get; set; }
        private Unit LineWidth { get; set; }

        public ReportBase()
        {
            InitializeComponent();

            BorderColor = Color.Gray;
            BorderStyle = BorderType.Solid;
            BorderWidth = Unit.Pixel(0.5D);
            LineColor = Color.Gray;
            LineWidth = Unit.Pixel(0.5D);

            txtEmpresa.Value = Helper.Empresa;
            txtRodapeEsquerdo.Value = $"ProdutorOnline.com";
            txtRodapeCentro.Value = $"V.{Helper.Versao}";
        }

        public void ocultarDataHora()
        {
            txtData.Value = "";
        }

        public void nomeiaTitulo(string titulo, double sizeWidtxtTitulo = 0)
        {
            Logo.Value = Helper.user.logo;

            if (sizeWidtxtTitulo > 0)
            {
                txtEmpresa.Width = Unit.Pixel(sizeWidtxtTitulo);
                txtTitulo.Width = Unit.Pixel(sizeWidtxtTitulo);
                txtSubTitulo.Width = Unit.Pixel(sizeWidtxtTitulo);
            }

            txtTitulo.Value = titulo;

            if (this.DocumentName.Trim().Length == 0 && titulo.Trim().Length > 0)
                this.DocumentName = titulo.RemoveAccents().Replace(" ", "_");
        }

        public void nomeiaSubTitulo(string subtitulo, double sizeWidtxtTitulo = 0)
        {
            if (sizeWidtxtTitulo > 0)
            {
                //txtEmpresa.Width = Unit.Pixel(sizeWidtxtTitulo);
                //txtTitulo.Width = Unit.Pixel(sizeWidtxtTitulo);
                //txtSubTitulo.Width = Unit.Pixel(sizeWidtxtTitulo);
                txtSubTitulo.Style.Font.Size = Unit.Point(12);
            }

            txtSubTitulo.Value = subtitulo;
        }

        private void AlterTable(Table tb)
        {
            if (tb.Style.BorderStyle.Default == BorderType.Solid)
            {
                tb.Style.BorderColor.Default = BorderColor;
                tb.Style.BorderStyle.Default = BorderStyle;
                tb.Style.BorderWidth.Default = BorderWidth;
            }

            if (tb.Style.BorderStyle.Top == BorderType.Solid)
            {
                tb.Style.BorderColor.Top = BorderColor;
                tb.Style.BorderStyle.Top = BorderStyle;
                tb.Style.BorderWidth.Top = BorderWidth;
            }

            if (tb.Style.BorderStyle.Bottom == BorderType.Solid)
            {
                tb.Style.BorderColor.Bottom = BorderColor;
                tb.Style.BorderStyle.Bottom = BorderStyle;
                tb.Style.BorderWidth.Bottom = BorderWidth;
            }

            if (tb.Style.BorderStyle.Left == BorderType.Solid)
            {
                tb.Style.BorderColor.Left = BorderColor;
                tb.Style.BorderStyle.Left = BorderStyle;
                tb.Style.BorderWidth.Left = BorderWidth;
            }

            if (tb.Style.BorderStyle.Right == BorderType.Solid)
            {
                tb.Style.BorderColor.Right = BorderColor;
                tb.Style.BorderStyle.Right = BorderStyle;
                tb.Style.BorderWidth.Right = BorderWidth;
            }

            tb.Style.LineColor = LineColor;
            tb.Style.LineWidth = LineWidth;

            foreach (var item in tb.Items)
            {
                if (item is Table)
                {
                    var tb2 = item as Table;
                    AlterTable(tb2);
                }
                else if (item is TextBox)
                {
                    var txt = item as TextBox;
                    AlterTextBox(txt);
                }
                else if (item is PictureBox)
                {
                    var pb = item as PictureBox;
                    AlterPictureBox(pb);
                }
                else if (item is HtmlTextBox)
                {
                    var html = item as HtmlTextBox;
                    AlterHtmlTextBox(html);
                }
            }
        }

        private void AlterTextBox(TextBox txt)
        {
            if (txt.Style.BorderStyle.Default == BorderType.Solid)
            {
                txt.Style.BorderColor.Default = BorderColor;
                txt.Style.BorderStyle.Default = BorderStyle;
                txt.Style.BorderWidth.Default = BorderWidth;
            }

            if (txt.Style.BorderStyle.Top == BorderType.Solid)
            {
                txt.Style.BorderColor.Top = BorderColor;
                txt.Style.BorderStyle.Top = BorderStyle;
                txt.Style.BorderWidth.Top = BorderWidth;
            }

            if (txt.Style.BorderStyle.Bottom == BorderType.Solid)
            {
                txt.Style.BorderColor.Bottom = BorderColor;
                txt.Style.BorderStyle.Bottom = BorderStyle;
                txt.Style.BorderWidth.Bottom = BorderWidth;
            }

            if (txt.Style.BorderStyle.Left == BorderType.Solid)
            {
                txt.Style.BorderColor.Left = BorderColor;
                txt.Style.BorderStyle.Left = BorderStyle;
                txt.Style.BorderWidth.Left = BorderWidth;
            }

            if (txt.Style.BorderStyle.Right == BorderType.Solid)
            {
                txt.Style.BorderColor.Right = BorderColor;
                txt.Style.BorderStyle.Right = BorderStyle;
                txt.Style.BorderWidth.Right = BorderWidth;
            }

            txt.Style.LineColor = LineColor;
            txt.Style.LineWidth = LineWidth;
        }

        private void AlterPictureBox(PictureBox pb)
        {
            if (pb.Style.BorderStyle.Default == BorderType.Solid)
            {
                pb.Style.BorderColor.Default = BorderColor;
                pb.Style.BorderStyle.Default = BorderStyle;
                pb.Style.BorderWidth.Default = BorderWidth;
            }

            if (pb.Style.BorderStyle.Top == BorderType.Solid)
            {
                pb.Style.BorderColor.Top = BorderColor;
                pb.Style.BorderStyle.Top = BorderStyle;
                pb.Style.BorderWidth.Top = BorderWidth;
            }

            if (pb.Style.BorderStyle.Bottom == BorderType.Solid)
            {
                pb.Style.BorderColor.Bottom = BorderColor;
                pb.Style.BorderStyle.Bottom = BorderStyle;
                pb.Style.BorderWidth.Bottom = BorderWidth;
            }

            if (pb.Style.BorderStyle.Left == BorderType.Solid)
            {
                pb.Style.BorderColor.Left = BorderColor;
                pb.Style.BorderStyle.Left = BorderStyle;
                pb.Style.BorderWidth.Left = BorderWidth;
            }

            if (pb.Style.BorderStyle.Right == BorderType.Solid)
            {
                pb.Style.BorderColor.Right = BorderColor;
                pb.Style.BorderStyle.Right = BorderStyle;
                pb.Style.BorderWidth.Right = BorderWidth;
            }

            pb.Style.LineColor = LineColor;
            pb.Style.LineWidth = LineWidth;
        }

        private void AlterHtmlTextBox(HtmlTextBox html)
        {
            if (html.Style.BorderStyle.Default == BorderType.Solid)
            {
                html.Style.BorderColor.Default = BorderColor;
                html.Style.BorderStyle.Default = BorderStyle;
                html.Style.BorderWidth.Default = BorderWidth;
            }

            if (html.Style.BorderStyle.Top == BorderType.Solid)
            {
                html.Style.BorderColor.Top = BorderColor;
                html.Style.BorderStyle.Top = BorderStyle;
                html.Style.BorderWidth.Top = BorderWidth;
            }

            if (html.Style.BorderStyle.Bottom == BorderType.Solid)
            {
                html.Style.BorderColor.Bottom = BorderColor;
                html.Style.BorderStyle.Bottom = BorderStyle;
                html.Style.BorderWidth.Bottom = BorderWidth;
            }

            if (html.Style.BorderStyle.Left == BorderType.Solid)
            {
                html.Style.BorderColor.Left = BorderColor;
                html.Style.BorderStyle.Left = BorderStyle;
                html.Style.BorderWidth.Left = BorderWidth;
            }

            if (html.Style.BorderStyle.Right == BorderType.Solid)
            {
                html.Style.BorderColor.Right = BorderColor;
                html.Style.BorderStyle.Right = BorderStyle;
                html.Style.BorderWidth.Right = BorderWidth;
            }

            html.Style.LineColor = LineColor;
            html.Style.LineWidth = LineWidth;
        }

        private void ReportBase_ItemDataBinding(object sender, EventArgs e)
        {
            foreach (var item in this.Items)
            {
                if (item is DetailSection)
                {
                    var pai = item as DetailSection;
                    foreach (var filho in pai.Items)
                    {
                        if (filho is Table)
                        {
                            var tb = filho as Table;
                            AlterTable(tb);
                        }
                        else if (filho is TextBox)
                        {
                            var txt = filho as TextBox;
                            AlterTextBox(txt);
                        }
                        else if (filho is PictureBox)
                        {
                            var pb = filho as PictureBox;
                            AlterPictureBox(pb);
                        }
                        else if (filho is HtmlTextBox)
                        {
                            var html = filho as HtmlTextBox;
                            AlterHtmlTextBox(html);
                        }
                    }
                }
            }
        }
    }
}