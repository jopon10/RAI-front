using System.Collections.Generic;
using System.Windows;
using RAI.ViewModel;
using RAI.Controls;
using RAI.API;
using System;

namespace RAI.Pages.Agricola.AnalisesSolo
{
    public partial class PageAnaliseSoloInclude : WindowBase
    {
        public AnaliseSolo analise { get; set; }

        public List<Parceiro> parceiros { get; set; }
        public List<Local> locais { get; set; }

        private List<ProdutoMovimento> movimentos { get; set; }

        public PageAnaliseSoloInclude()
        {
            InitializeComponent();
        }

        private async void WindowBase_Loaded(object sender, RoutedEventArgs e)
        {
            btGravar.IsLoading(true);

            if (parceiros == null) parceiros = await CadastroAPI.GetParceirosAsync(tipo: "fornecedor", minimal: true);
            if (locais == null) locais = await CadastroAPI.GetLocaisAsync(minimal: true);

            cbParceiros.ItemsSource = parceiros;
            cbLocais.ItemsSource = locais;

            d1.SelectedDate = DateTime.Today;

            if (analise != null)
            {
                cbParceiros.SelectedValue = analise.parceiro_id;
                cbLocais.SelectedValue = analise.local_id;
                if (analise.quadra_id != null) cbQuadras.SelectedValue = analise.quadra_id;
                d1.SelectedDate = analise.data;
                cbProdundidade.Text = analise.profundidade;
                txtObs.Text = analise.observacao;
            }
            else
            {
                analise = new AnaliseSolo();
                cbParceiros.Focus();
            }

            movimentos = new List<ProdutoMovimento>();
            movimentos.Add(new ProdutoMovimento { id = 0, nomeProduto = "pH", quantidade = analise.ph, extratores = new List<Unidade> { new Unidade { sigla = "H2O" }, new Unidade { sigla = "CaCl2" } }, unidades_analise_solo = new List<Unidade> { new Unidade { sigla = "-" } }, extrator = "CaCl2", unidade = "-" });
            movimentos.Add(new ProdutoMovimento { id = 1, nomeProduto = "M.O.", quantidade = analise.mo, extratores = new List<Unidade> { new Unidade { sigla = "Cálculo" } }, unidades_analise_solo = new List<Unidade> { new Unidade { sigla = "g/kg" }, new Unidade { sigla = "g/dm3" }, new Unidade { sigla = "%" }, new Unidade { sigla = "dag/kg" }, new Unidade { sigla = "dag/dm3" } }, extrator = "Cálculo", unidade = "%" });
            movimentos.Add(new ProdutoMovimento { id = 2, nomeProduto = "P", quantidade = analise.p, extratores = new List<Unidade> { new Unidade { sigla = "Resina" }, new Unidade { sigla = "Mehlich 1" } }, unidades_analise_solo = new List<Unidade> { new Unidade { sigla = "mg/dm3" } }, extrator = "Resina", unidade = "mg/dm3" });
            movimentos.Add(new ProdutoMovimento { id = 3, nomeProduto = "K", quantidade = analise.k, extratores = new List<Unidade> { new Unidade { sigla = "Resina" }, new Unidade { sigla = "Mehlich 1" } }, unidades_analise_solo = new List<Unidade> { new Unidade { sigla = "mmolc/dm3" }, new Unidade { sigla = "cmolc/dm3" }, new Unidade { sigla = "mg/dm3" } }, extrator = "Resina", unidade = "cmolc/dm3" });
            movimentos.Add(new ProdutoMovimento { id = 4, nomeProduto = "Ca", quantidade = analise.ca, extratores = new List<Unidade> { new Unidade { sigla = "KCl" } }, unidades_analise_solo = new List<Unidade> { new Unidade { sigla = "mmolc/dm3" }, new Unidade { sigla = "cmolc/dm3" } }, extrator = "KCl", unidade = "cmolc/dm3" });
            movimentos.Add(new ProdutoMovimento { id = 5, nomeProduto = "Mg", quantidade = analise.mg, extratores = new List<Unidade> { new Unidade { sigla = "KCl" } }, unidades_analise_solo = new List<Unidade> { new Unidade { sigla = "mmolc/dm3" }, new Unidade { sigla = "cmolc/dm3" } }, extrator = "KCl", unidade = "cmolc/dm3" });
            movimentos.Add(new ProdutoMovimento { id = 6, nomeProduto = "Na", quantidade = analise.na, extratores = new List<Unidade> { new Unidade { sigla = "Mehlich" } }, unidades_analise_solo = new List<Unidade> { new Unidade { sigla = "mmolc/dm3" }, new Unidade { sigla = "cmolc/dm3" } }, extrator = "Mehlich", unidade = "cmolc/dm3" });
            movimentos.Add(new ProdutoMovimento { id = 7, nomeProduto = "H+Al", quantidade = analise.h_al, extratores = new List<Unidade> { new Unidade { sigla = "Cálculo" } }, unidades_analise_solo = new List<Unidade> { new Unidade { sigla = "mmolc/dm3" }, new Unidade { sigla = "cmolc/dm3" } }, extrator = "Cálculo", unidade = "cmolc/dm3" });
            movimentos.Add(new ProdutoMovimento { id = 8, nomeProduto = "Al", quantidade = analise.al, extratores = new List<Unidade> { new Unidade { sigla = "KCl" } }, unidades_analise_solo = new List<Unidade> { new Unidade { sigla = "mmolc/dm3" }, new Unidade { sigla = "cmolc/dm3" } }, extrator = "KCl", unidade = "cmolc/dm3" });
            movimentos.Add(new ProdutoMovimento { id = 9, nomeProduto = "S", quantidade = analise.s, extratores = new List<Unidade> { new Unidade { sigla = "Ca3(PO4)2" } }, unidades_analise_solo = new List<Unidade> { new Unidade { sigla = "mg/dm3" } }, extrator = "Ca3(PO4)2", unidade = "mg/dm3" });
            movimentos.Add(new ProdutoMovimento { id = 10, nomeProduto = "B", quantidade = analise.b, extratores = new List<Unidade> { new Unidade { sigla = "Água Quente" } }, unidades_analise_solo = new List<Unidade> { new Unidade { sigla = "mg/dm3" } }, extrator = "Água Quente", unidade = "mg/dm3" });
            movimentos.Add(new ProdutoMovimento { id = 11, nomeProduto = "Cu", quantidade = analise.cu, extratores = new List<Unidade> { new Unidade { sigla = "Mehlich 1" }, new Unidade { sigla = "DTPA" } }, unidades_analise_solo = new List<Unidade> { new Unidade { sigla = "mg/dm3" } }, extrator = "DTPA", unidade = "mg/dm3" });
            movimentos.Add(new ProdutoMovimento { id = 12, nomeProduto = "Fe", quantidade = analise.fe, extratores = new List<Unidade> { new Unidade { sigla = "Mehlich 1" }, new Unidade { sigla = "DTPA" } }, unidades_analise_solo = new List<Unidade> { new Unidade { sigla = "mg/dm3" } }, extrator = "DTPA", unidade = "mg/dm3" });
            movimentos.Add(new ProdutoMovimento { id = 13, nomeProduto = "Mn", quantidade = analise.mn, extratores = new List<Unidade> { new Unidade { sigla = "Mehlich 1" }, new Unidade { sigla = "DTPA" } }, unidades_analise_solo = new List<Unidade> { new Unidade { sigla = "mg/dm3" } }, extrator = "DTPA", unidade = "mg/dm3" });
            movimentos.Add(new ProdutoMovimento { id = 14, nomeProduto = "Zn", quantidade = analise.zn, extratores = new List<Unidade> { new Unidade { sigla = "Mehlich 1" }, new Unidade { sigla = "DTPA" } }, unidades_analise_solo = new List<Unidade> { new Unidade { sigla = "mg/dm3" } }, extrator = "DTPA", unidade = "mg/dm3" });
            movimentos.Add(new ProdutoMovimento { id = 15, nomeProduto = "Argila", quantidade = analise.argila, extratores = new List<Unidade> { new Unidade { sigla = "HMFS + NaOH" } }, unidades_analise_solo = new List<Unidade> { new Unidade { sigla = "g/kg" }, new Unidade { sigla = "g/dm3" }, new Unidade { sigla = "%" } }, extrator = "HMFS + NaOH", unidade = "%" });
            movimentos.Add(new ProdutoMovimento { id = 16, nomeProduto = "Silte", quantidade = analise.silte, extratores = new List<Unidade> { new Unidade { sigla = "HMFS + NaOH" } }, unidades_analise_solo = new List<Unidade> { new Unidade { sigla = "g/kg" }, new Unidade { sigla = "g/dm3" }, new Unidade { sigla = "%" } }, extrator = "HMFS + NaOH", unidade = "%" });
            movimentos.Add(new ProdutoMovimento { id = 17, nomeProduto = "Areia", quantidade = analise.areia, extratores = new List<Unidade> { new Unidade { sigla = "HMFS + NaOH" } }, unidades_analise_solo = new List<Unidade> { new Unidade { sigla = "g/kg" }, new Unidade { sigla = "g/dm3" }, new Unidade { sigla = "%" } }, extrator = "HMFS + NaOH", unidade = "%" });
            grid.ItemsSource = movimentos;

            btGravar.IsLoading(false);
        }

        private async void cbLocais_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbLocais.SelectedItem == null)
            {
                cbQuadras.ItemsSource = null;
                return;
            }

            btGravar.IsLoading(true);

            var local = cbLocais.SelectedItem as Local;
            var quadras = await CadastroAPI.GetLocaisQuadrasAsync(local);
            cbQuadras.ItemsSource = quadras;

            btGravar.IsLoading(false);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbParceiros.SelectedItem == null)
            {
                cbParceiros.Focus();
                return;
            }

            if (cbLocais.SelectedItem == null)
            {
                cbLocais.Focus();
                return;
            }

            if (d1.SelectedDate == null)
            {
                d1.Focus();
                return;
            }

            if (cbProdundidade.SelectedItem == null)
            {
                cbProdundidade.Focus();
                return;
            }

            try
            {
                btGravar.IsLoading(true);

                var parceiro = cbParceiros.SelectedItem as Parceiro;
                var local = cbLocais.SelectedItem as Local;

                analise.parceiro_id = parceiro.id;
                analise.local_id = local.id;
                analise.quadra_id = cbQuadras.SelectedValue.GetValueOrNull();
                analise.data = d1.SelectedDate.Value;
                analise.profundidade = cbProdundidade.Text;
                analise.observacao = txtObs.Text;

                foreach (var item in movimentos)
                {
                    switch (item.id)
                    {
                        case 0:
                            analise.ph = item.quantidade;
                            analise.ph_extrator = item.extrator;
                            break;
                        case 1:
                            analise.mo = item.quantidade;
                            analise.mo_unidade = item.unidade;
                            break;
                        case 2:
                            analise.p = item.quantidade;
                            analise.p_extrator = item.extrator;
                            break;
                        case 3:
                            analise.k = item.quantidade;
                            analise.k_extrator = item.extrator;
                            analise.k_unidade = item.unidade;
                            break;
                        case 4:
                            analise.ca = item.quantidade;
                            analise.ca_unidade = item.unidade;
                            break;
                        case 5:
                            analise.mg = item.quantidade;
                            analise.mg_unidade = item.unidade;
                            break;
                        case 6:
                            analise.na = item.quantidade;
                            analise.na_unidade = item.unidade;
                            break;
                        case 7:
                            analise.h_al = item.quantidade;
                            analise.h_al_unidade = item.unidade;
                            break;
                        case 8:
                            analise.al = item.quantidade;
                            analise.al_unidade = item.unidade;
                            break;
                        case 9:
                            analise.s = item.quantidade;
                            break;
                        case 10:
                            analise.b = item.quantidade;
                            break;
                        case 11:
                            analise.cu = item.quantidade;
                            analise.cu_extrator = item.extrator;
                            break;
                        case 12:
                            analise.fe = item.quantidade;
                            analise.fe_extrator = item.extrator;
                            break;
                        case 13:
                            analise.mn = item.quantidade;
                            analise.mn_extrator = item.extrator;
                            break;
                        case 14:
                            analise.zn = item.quantidade;
                            analise.zn_extrator = item.extrator;
                            break;
                        case 15:
                            analise.argila = item.quantidade;
                            analise.argila_unidade = item.unidade;
                            break;
                        case 16:
                            analise.silte = item.quantidade;
                            analise.silte_unidade = item.unidade;
                            break;
                        case 17:
                            analise.areia = item.quantidade;
                            analise.areia_unidade = item.unidade;
                            break;

                        default:
                            break;
                    }
                }

                if (analise.id == 0)
                    analise = await AgricolaAPI.PostAnaliseSoloAsync(analise);
                else
                    await AgricolaAPI.PutAnaliseSoloAsync(analise);

                analise.parceiro = parceiro.nome;
                analise.fazenda_id = local.fazenda_id.GetValueOrDefault();
                analise.fazenda = local.fazenda;
                analise.local = local.nome;
                analise.quadra = cbQuadras.Text;

                gravou = true;
                Close();
            }
            catch (Exception ex)
            {
                Helper.ShowPonDialog(ex.Message, tipoMensagem: MessageBoxImage.Exclamation);
                btGravar.IsLoading(false);
            }
        }
    }
}