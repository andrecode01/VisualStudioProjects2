using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerce.adm
{
    public partial class CadastrarProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                popularDdlSubcategorias(Subcategoria.ObterSubcategorias());
            }

        }

        private void popularDdlSubcategorias(List<Subcategoria> cats)
        {
            ddlSubcategorias.DataSource =
                cats.OrderBy(item => item.NomeSubcategoria).ToList();
            ddlSubcategorias.DataTextField = "NomeSubcategoria";
            ddlSubcategorias.DataValueField = "IdSubcategoria";
            ddlSubcategorias.DataBind();
        }

        protected void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            Produto p = new Produto();
            p.NomeProduto = inpNomeProduto.Value;
            p.PesoVolumeProduto = Convert.ToDecimal(inpPesoVolume.Value);
            p.PrecoProduto = Convert.ToDecimal(inpPreco.Value);
            p.EstoqueProduto = 0;
            p.Produto_IdSubcategoria = Subcategoria
                .ObterSubcategorias()
                .FirstOrDefault(s => s.IdSubcategoria == Convert.ToInt32(ddlSubcategorias.SelectedValue))
                .IdSubcategoria;
            var qtdEstoque = Convert.ToInt32(inpEstoque.Value);

            Produto.CadastrarProduto(p, qtdEstoque);
        }
    }
}