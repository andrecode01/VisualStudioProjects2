using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerce
{
    public partial class CarrinhoUsuarioProduto
    {

        public static List<CarrinhoUsuarioProduto> ObterCarrinhoUsuarioProduto (int idU, int codP)
        {
            using (var ctx = new EcommerceDBEntities1())
            {
                List<CarrinhoUsuarioProduto> car = new List<CarrinhoUsuarioProduto>();
                var carTotal = ctx.CarrinhoUsuarioProdutoes.ToList();
                for (int i = 0; i < carTotal.Count(); i++)
                    if (carTotal[i].CarrinhoUsuario.Usuario.IdUsuario == idU 
                        && carTotal[i].ProdutoItem.CodigoProduto == codP)
                        car.Add(carTotal[i]);

                return car;
            }
        }

        public static void AddItemCarrinho (int idU, int codP)
        {
            CarrinhoUsuarioProduto cup = new CarrinhoUsuarioProduto();

            using (var ctx = new EcommerceDBEntities1())
            {
                var pi = ProdutoItem.ObterEstoqueByProduto(codP).FirstOrDefault();
                var car = CarrinhoUsuario.ObterCarrinhoByUsuario(idU);

                cup.IdCarrinhoUsuario = car.IdCarrinhoUsuario;
                cup.CodigoProdutoItem = pi.CodigoProdutoItem;

                ctx.CarrinhoUsuarioProdutoes.Add(cup);
                ctx.SaveChanges();
                var valor = Produto.ObterPrecoByCodigo(codP);
                CarrinhoUsuario.AtualizarCarrinho(idU, valor, true);
            }
        }

        public static void RemoveItemCarrinho(int idU, int codP)
        {
            using (var ctx = new EcommerceDBEntities1())
            {
                var cup = ctx.CarrinhoUsuarioProdutoes.
                    FirstOrDefault(c => c.CarrinhoUsuario.Carrinho_IdUsuario == idU);
                if(cup != null)
                {    
                    ctx.CarrinhoUsuarioProdutoes.Remove(cup);
                    ctx.SaveChanges();
                    var valor = Produto.ObterPrecoByCodigo(codP);
                    CarrinhoUsuario.AtualizarCarrinho(idU, valor, false);
                }
            }
        }

    }
}