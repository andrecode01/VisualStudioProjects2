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
    
    public partial class CarrinhoUsuarioProduto
    {
        public int IdCarrinhoUsuarioProduto { get; set; }
        public int IdCarrinhoUsuario { get; set; }
        public int CodigoProdutoItem { get; set; }
    
        public virtual CarrinhoUsuario CarrinhoUsuario { get; set; }
        public virtual ProdutoItem ProdutoItem { get; set; }
    }
}
