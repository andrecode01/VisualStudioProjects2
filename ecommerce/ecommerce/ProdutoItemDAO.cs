﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerce
{
    public partial class ProdutoItem
    {

        public static void AdicionarProdutoItemEstoque(int codP, int qtdEstoque)
        {
            ProdutoItem pi = new ProdutoItem();

            using (var ctx = new EcommerceDBEntities1())
            {
                pi.CodigoProduto = codP;
                pi.SituacaoItem = "disponivel";
                for (var i = 0; i < qtdEstoque; i++)
                {
                    ctx.ProdutoItems.Add(pi);
                    ctx.SaveChanges();
                    Produto.AtualizarEstoque(codP);
                }
            }
        }

        public static void RemoverProdutoItemEstoque(int codP, int idU)
        {
            /*var piEstoque = ProdutoItem.ObterEstoqueByProduto(codP);
            var listaCUP = CarrinhoUsuarioProduto.ObterCarrinhoUsuarioProduto(idU, codP).ToList();

            for (int i = 0; i < piEstoque.Count(); i++)
                if(listaCUP.FirstOrDefault(lcup => lcup.CodigoProdutoItem == piEstoque[i].CodigoProdutoItem) != null)
                    CarrinhoUsuarioProduto.RemoveItemCarrinho(piEstoque[i])*/
        }

        public static List<ProdutoItem> ObterEstoqueByProduto(int codP)
        {
            using (var ctx = new EcommerceDBEntities1())
            {
                var  estoque = ctx.ProdutoItems.ToList();
                List<ProdutoItem> estoquefiltro = new List<ProdutoItem>();
                var cont = ctx.ProdutoItems.Count();

                for (int i = 0; i < cont; i++)
                    if (estoque[i].CodigoProduto == codP)
                        estoquefiltro.Add(estoque[i]);

                return estoquefiltro;
            }
        }

    }
}