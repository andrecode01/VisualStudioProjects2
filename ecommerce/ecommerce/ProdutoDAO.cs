using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerce
{
    public partial class Produto
    {

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
                CadastrarProduto(p);

                for(var j = 0;  j < qtd; j++)
                    ProdutoItem.AdicionarProdutoItemEstoque(p.CodigoProduto);
            }
        }

        public static void CadastrarProduto(Produto p)
        {
            using (var ctx = new EcommerceDBEntities1())
            {
                ctx.Produtoes.Add(p);
                ctx.SaveChanges();
            }
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