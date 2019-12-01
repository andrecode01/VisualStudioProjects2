using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerce
{
    public partial class Produto
    {

        public string GetNomeSubcategoria
        {
            get
            {
                using (var ctx = new EcommerceDBEntities1())
                {
                    return ctx.Subcategorias
                        .FirstOrDefault(cat => cat.IdSubcategoria == Produto_IdSubcategoria)
                        .NomeSubcategoria;
                }
            }
        }

        public int ItensDisponiveis
        {
            get { 
                using (var ctx = new EcommerceDBEntities1())
                {
                    int itd = 0;
                    List<ProdutoItem> lpi = ProdutoItem.ObterEstoqueByProduto(CodigoProduto);
                    for (int i = 0; i < lpi.Count(); i++)
                        if (lpi[i].CodigoProduto == CodigoProduto && lpi[i].SituacaoItem == "disponivel")
                            itd++;

                    return itd;
                }
            }
        }

        public static List<Produto> ObterProdutos()
        {
            List<Produto> produtos = new List<Produto>();
            using (var ctx = new EcommerceDBEntities1())
            {
                produtos = ctx.Produtoes.ToList();
            }

            return produtos;
        }

        public static void AtualizarEstoque(int codP)
        {
            using (var ctx = new EcommerceDBEntities1())
            {
                ctx.Produtoes.FirstOrDefault(p => p.CodigoProduto == codP).EstoqueProduto++;
                ctx.SaveChanges();
            }
        }

        internal static void CriarProdutosDefault(int qtd)
        {
            Produto p = new Produto();

            for(var i = 1; i <= 5; i++)
            {
                p.CodigoProduto = i + 1000;
                p.NomeProduto = "Produto " + i;
                p.PesoVolumeProduto = i * 5;
                p.PrecoProduto = i * 10;

                var subcats = Subcategoria.ObterSubcategorias().ToList();
                p.Produto_IdSubcategoria = subcats[i - 1].IdSubcategoria;

                CadastrarProduto(p, 10);
            }
        }

        public static void CadastrarProduto(Produto p, int qtdEstoque)
        {
            using (var ctx = new EcommerceDBEntities1())
            {
                ctx.Produtoes.Add(p);
                ctx.SaveChanges();
            }

            
            ProdutoItem.AdicionarProdutoItemEstoque(p.CodigoProduto, qtdEstoque);
        }

        public static List<Produto> ObterProdutosBySubcategoria(string filtro)
        {
            List<Produto> lp = ObterProdutos().ToList();
            List<Produto> lpf = new List<Produto>();

            for (int i = 0; i < lp.Count(); i++)
                if (lp[i].Produto_IdSubcategoria == Convert.ToInt32(filtro))
                    lpf.Add(lp[i]);

            return lpf;
        }

        public static Produto ObterProdutoByCodigo(int cod)
        {
            Produto p = Produto.ObterProdutos().ToList().FirstOrDefault(pp => pp.CodigoProduto == cod);
            return p;
        }

        public static decimal ObterPrecoByCodigo(int id)
        {
            return Produto.ObterProdutoByCodigo(id).PrecoProduto;
        }
    }
}