using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerce
{
    public partial class ProdutoItem
    {

        public static void AdicionarProdutoItemEstoque(int codP)
        {
            ProdutoItem pi = new ProdutoItem();

            using (var ctx = new EcommerceDBEntities1())
            {
                pi.CodigoProduto = codP;
                ctx.ProdutoItems.Add(pi);
                ctx.SaveChanges();
                Produto.AtualizarEstoque(codP);
            }
        }

    }
}