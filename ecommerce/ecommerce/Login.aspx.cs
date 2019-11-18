using ecommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ecommerce
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Usuario.ListaUsuarios == null)
            {
                Usuario.criarUsuariosDefault();
            }

            if (!Page.IsPostBack)
            {
                popularLvUsuarios();
            }

            var qsLogar = Request.QueryString["login"];

            if (qsLogar != null)
            {
                forcarLogin(Usuario.ObterUsuarioByEmail(qsLogar));
            }

        }

        private void forcarLogin(Usuario usuario)
        {
            if (usuario == null)
                return;

            var u = usuario;

            FormsAuthentication.SetAuthCookie(u.Nome, true);
            Response.Redirect("~/");
        }

        private void popularLvUsuarios()
        {
            lvUsuarios.DataSource = Usuario.ListaUsuarios;
            lvUsuarios.DataBind();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            Usuario user = new Usuario();

            user.Email = inpEmail.Value;
            user.Nome = inpNome.Value;
            user.Senha = FormsAuthentication.HashPasswordForStoringInConfigFile(inpPass.Value, "SHA1");
            user.nivel = NivelUsuario.ObterNivelByNomeNivel(slctNivel.Value);

            if (Usuario.CadastrarUsuario(user))
                txtMenssagem.InnerText = "Cadastrado com Sucesso!";
            

            popularLvUsuarios();
            limparDadosCadastros();
        }

        private void limparDadosCadastros()
        {
            inpEmail.Value = "";
            inpNome.Value = "";
            inpPass.Value = "";
            slctNivel.SelectedIndex = 0;
        }
    }
}