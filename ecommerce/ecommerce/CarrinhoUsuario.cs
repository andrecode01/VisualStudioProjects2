//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ecommerce
{
    using System;
    using System.Collections.Generic;
    
    public partial class CarrinhoUsuario
    {
        public int IdCarrinho { get; set; }
        public decimal QuantidadeProdutos { get; set; }
        public decimal PrecoTotal { get; set; }
        public int Carrinho_IdUsuario { get; set; }
        public int Carrinho_CodigoProduto { get; set; }
    
        public virtual Produto Produto { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}