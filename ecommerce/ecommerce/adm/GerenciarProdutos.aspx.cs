using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerce.adm
{
    public partial class GerenciarProdutos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                popularLvGerenciarProdutos();
            }
        }

        private void popularLvGerenciarProdutos()
        {
            lvGerenciarProdutos.DataSource = Produto.ObterProdutos().ToList();
            lvGerenciarProdutos.DataBind();
        }
    }
}