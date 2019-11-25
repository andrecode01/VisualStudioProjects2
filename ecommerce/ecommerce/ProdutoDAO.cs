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
            using (var ctx = new EcommerceDBEntitiesNew())
            {
                produtos = ctx.Produtoes.ToList();
            }

            if (produtos.Count() == 0)
                CriarProdutosDefault();

            return produtos;
        }

        internal static void CriarProdutosDefault()
        {
            Produto p = new Produto();

            for(var i = 1; i <= 5; i++)
            {
                p.NomeProduto = "Produto" + i;
                p.PesoVolumeProduto = i * 5;
                p.PrecoProduto = i * 10;
                p.EstoqueProduto = i * i;
                CadastrarProduto(p);
            }
        }

        public static void CadastrarProduto(Produto p)
        {
            using (var ctx = new EcommerceDBEntitiesNew())
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