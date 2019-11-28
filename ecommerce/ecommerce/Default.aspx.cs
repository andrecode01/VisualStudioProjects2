using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerce
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.User.Identity.IsAuthenticated)
               Response.Redirect("~/Login.aspx");



            if (!Page.IsPostBack)
            {
                if (Produto.ObterProdutos().Count == 0)
                    Produto.CriarProdutosDefault(10);

                popularLvProdutos();

                var qsAdd = Request.QueryString["add"];

                int idU = Convert.ToInt32(Page.User.Identity.Name);

                if (qsAdd != null)
                {
                    int CodP = Convert.ToInt32(qsAdd);

                    if(Produto.ObterProdutoByCodigo(CodP) != null)
                        CarrinhoUsuario.AdicionarProdutoCarrinho(idU, CodP);
                }

            }
                

            carregarUsuarioAutenticado();

        }

        private void carregarUsuarioAutenticado()
        { 
            int id = Convert.ToInt32(Page.User.Identity.Name);
            Usuario userAuth = Usuario.ObterUsuarioById(id);

            if (userAuth != null)
            {
                NomeAuth.InnerHtml = userAuth.NomeUsuario;
            }
        }

        private void popularLvProdutos()
        {
            lvProdutos.DataSource = Produto.ObterProdutos();
            lvProdutos.DataBind();
        }
    }
}