using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerce
{
    public partial class PerfilUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var usuario = Usuario.ObterUsuarioById(Convert.ToInt32(Request.QueryString["user"]));
                if(usuario != null)
                {
                    NomeUsuario.InnerHtml = usuario.NomeUsuario;
                }
                else
                {
                    NomeUsuario.InnerHtml = "Usuário não encontrado!";
                }
            }
        }
    }
}