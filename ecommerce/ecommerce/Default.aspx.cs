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
        private static Usuario userAuth = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Page.User.Identity.Name);
            userAuth = Usuario.ObterUsuarioById(id);

            if (!Page.User.Identity.IsAuthenticated)
               Response.Redirect("~/Login.aspx");

            if (userAuth.getNomeNivel == "Admin")
                btnGerenciarProdutos.Visible = true;
            else
                btnGerenciarProdutos.Visible = false;

            if (!Page.IsPostBack)
            {
                if (Subcategoria.ObterSubcategorias().Count() == 0)
                    Subcategoria.CriarCategoriasDefault();

                if (Produto.ObterProdutos().Count == 0)
                    Produto.CriarProdutosDefault(10);

                popularLvFiltro();

                var filtro = Page.Request.QueryString["filtro"];

                if (filtro == null)
                    popularLvProdutos();
                else
                    popularLvProdutosFiltrando(filtro);

                CarrinhoUsuario.criarCarrinho(userAuth.IdUsuario);
            }
                
            carregarUsuarioAutenticado();
            carregarCarrinhoUsuario();

        }

        private void popularLvFiltro()
        {
            lvFiltro.DataSource = Subcategoria.ObterSubcategorias();
            lvFiltro.DataBind();
        }

        private void carregarCarrinhoUsuario()
        {
            qtdCar.InnerHtml = 
                Convert.ToString(CarrinhoUsuario.ObterCarrinhoByUsuario(userAuth.IdUsuario).QuantidadeProdutos);
            totalRsCar.InnerHtml = 
                Convert.ToString(CarrinhoUsuario.ObterCarrinhoByUsuario(userAuth.IdUsuario).PrecoTotal);
        }

        private void carregarUsuarioAutenticado()
        { 
            if (userAuth != null)
            {
                NomeAuth.InnerHtml = userAuth.NomeUsuario;
                NomeNivelAuth.InnerHtml = userAuth.getNomeNivel;
            }
        }

        private void popularLvProdutos()
        {
            lvProdutos.DataSource = Produto.ObterProdutos();
            lvProdutos.DataBind();
        }

        private void popularLvProdutosFiltrando(string filtro)
        {
            lvProdutos.DataSource = Produto.ObterProdutosBySubcategoria(filtro);
            lvProdutos.DataBind();
        }
    }
}