using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerce
{
    public partial class PerfilProduto : System.Web.UI.Page
    {
        private static int idUs;
        private static int codPs;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.User.Identity.IsAuthenticated)
                Response.Redirect("~/Login.aspx");

            if (!Page.IsPostBack)
            {
                int idU = Convert.ToInt32(Page.User.Identity.Name);
                idUs = idU;
                var cod = Convert.ToInt32(Request.QueryString["cod"]);
                codPs = cod;

                var nome = Usuario.ObterUsuarioById(idU).NomeUsuario;
                linkCarrinhoUsuario.InnerHtml = "Ir para Carrinho["+nome+"]";
                linkCarrinhoUsuario.HRef= "PerfilUsuario.aspx?user="+idUs;

                var p = Produto.ObterProdutoByCodigo(cod);

                if(p != null)
                {
                    NomeProdutoAuth.InnerHtml = p.NomeProduto;
                    Page.Title = Page.Title+p.NomeProduto;

                    if(CarrinhoUsuarioProduto.ObterCarrinhoUsuarioProduto(idU, p.CodigoProduto).Count > 0)
                    {
                        btnAddCarrinho.Style.Add("display", "none");
                        btnRemoveCarrinho.Style.Add("display", "block");
                    }
                    else
                    {
                        btnAddCarrinho.Style.Add("display", "block");
                        btnRemoveCarrinho.Style.Add("display", "none");
                    }

                }
                else
                {
                    NomeProdutoAuth.InnerHtml = "Produto não encontrado";
                }
            }

        }

        protected void btnAddCarrinho_Click(object sender, EventArgs e)
        {
            CarrinhoUsuarioProduto.AddItemCarrinho(idUs, codPs);
            Page.Response.Redirect("PerfilProduto.aspx?cod=" + codPs);
        }

        protected void btnRemoveCarrinho_Click(object sender, EventArgs e)
        {
            CarrinhoUsuarioProduto.RemoveItemCarrinho(idUs, codPs);
            Page.Response.Redirect("PerfilProduto.aspx?cod=" + codPs);
        }
    }
}