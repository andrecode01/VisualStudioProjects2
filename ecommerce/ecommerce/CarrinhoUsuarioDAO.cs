using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerce
{
    public partial  class CarrinhoUsuario
    {

        public static List<CarrinhoUsuario> ObterCarrinhosByUsuario(int id)
        {
            List<CarrinhoUsuario> cars = new List<CarrinhoUsuario>();

            using (var ctx = new EcommerceDBEntitiesNew())
            {
                return cars = ctx.CarrinhoUsuarios.ToList();
            }

        }

        public static void AdicionarProdutoCarrinho(int idU, int idP)
        {
            var cars = ObterCarrinhosByUsuario(idU);

            if (cars.Count > 0 )
            {
                if (cars.FirstOrDefault(p => p.Carrinho_CodigoProduto == idP) != null)
                {
                    var car = cars.FirstOrDefault(p => p.Carrinho_CodigoProduto == idP);
                    car.QuantidadeProdutos++;
                    Produto.ObterProdutoByCodigo(idP).EstoqueProduto--;
                    car.PrecoTotal = Produto.ObterPrecoByCodigo(idP) * car.QuantidadeProdutos;
                }
                
            }else
             {
                criarCarrinho(idU, idP);
             }
        }

        private static void criarCarrinho(int idU, int codP)
        {
            CarrinhoUsuario car = new CarrinhoUsuario();

            car.Carrinho_IdUsuario = idU;
            car.Carrinho_CodigoProduto = codP;
            car.PrecoTotal = Produto.ObterPrecoByCodigo(codP);
            car.QuantidadeProdutos = 1;

            using (var ctx = new EcommerceDBEntitiesNew())
            {
                ctx.CarrinhoUsuarios.Add(car);
                ctx.SaveChanges();
            }
        }
    }
}