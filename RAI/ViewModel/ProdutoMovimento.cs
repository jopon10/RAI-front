using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAI.ViewModel
{
    public class ProdutoMovimento
    {
        public ProdutoMovimento()
        {
            extratores = new List<Unidade>();
            unidades_analise_solo = new List<Unidade>();
        }

        public int id { get; set; }
        public string nomeProduto { get; set; }
        public decimal? quantidade { get; set; }
        public string unidade { get; set; }
        public string extrator { get; set; }
        public List<Unidade> extratores { get; set; }
        public List<Unidade> unidades_analise_solo { get; set; }
    }
}