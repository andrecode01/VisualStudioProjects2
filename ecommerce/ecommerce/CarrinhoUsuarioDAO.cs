using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerce
{
    public partial  class CarrinhoUsuario
    {

        public static CarrinhoUsuario ObterCarrinhoByUsuario(int idU)
        {
            using (var ctx = new EcommerceDBEntities1())
            {
                var car = ctx.CarrinhoUsuarios.FirstOrDefault(c => c.Carrinho_IdUsuario == idU);
                return car;
            }
        }

        public static void criarCarrinho(int idU)
        {
            using (var ctx = new EcommerceDBEntities1())
            {
                if(ctx.CarrinhoUsuarios.FirstOrDefault(c => c.Carrinho_IdUsuario == idU) == null)
                {
                    CarrinhoUsuario car = new CarrinhoUsuario();
                    car.QuantidadeProdutos = 0;
                    car.PrecoTotal = 0;
                    car.Carrinho_IdUsuario = idU;
                    ctx.CarrinhoUsuarios.Add(car);
                    ctx.SaveChanges();
                } 
            }
        }

        public static void AtualizarCarrinho(int idU, decimal valor, bool add)
        {
            using (var ctx = new EcommerceDBEntities1())
            {
                if (add)
                {
                    ctx.CarrinhoUsuarios.FirstOrDefault(c => c.Carrinho_IdUsuario == idU).QuantidadeProdutos++;
                    ctx.CarrinhoUsuarios.FirstOrDefault(c => c.Carrinho_IdUsuario == idU).PrecoTotal += valor;
                }
                else
                {
                    ctx.CarrinhoUsuarios.FirstOrDefault(c => c.Carrinho_IdUsuario == idU).QuantidadeProdutos--;
                    ctx.CarrinhoUsuarios.FirstOrDefault(c => c.Carrinho_IdUsuario == idU).PrecoTotal -= valor;
                }
                ctx.SaveChanges();
            }
        }
    }
}