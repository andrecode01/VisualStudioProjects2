using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerce.adm
{
    public partial class CadastrarSubcategoria : System.Web.UI.Page
    {

        private static Usuario userAuth = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                int id = Convert.ToInt32(Page.User.Identity.Name);
                userAuth = Usuario.ObterUsuarioById(id);

                if (!Page.User.Identity.IsAuthenticated)
                    Response.Redirect("../Login.aspx");

                if (userAuth.getNomeNivel != "Admin")
                    Response.Redirect("../Default.aspx");


            }

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            var nomeSubcategoria = inpNomeCategoria.Value;

            Subcategoria.CriarCategorias(nomeSubcategoria);
            inpNomeCategoria.Value = "";
        }
    }
}