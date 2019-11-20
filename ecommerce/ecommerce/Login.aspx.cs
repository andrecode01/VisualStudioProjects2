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
        private static bool criarBd = true;
        protected void Page_Load(object sender, EventArgs e)
        {

            using (var ctx = new EcommerceDBEntities())
            {
                
                while (criarBd == true) { 
                var deleteCommand = ctx.Database.Connection.CreateCommand();
                deleteCommand.CommandText = "DELETE FROM Usuario";
                ctx.Database.Connection.Open();
                deleteCommand.ExecuteNonQuery();
                ctx.Database.Connection.Close();
                    criarBd = false;
                }
                List<Usuario> usuarios = (from u in ctx.Usuarios select u).ToList();
                if(usuarios.Count() == 0)
                {
                    Usuario.criarUsuariosDefault();
                }
                
            }

            if (!Page.IsPostBack)
            {
                popularLvUsuarios();
            }

            var qsLogar = Request.QueryString["login"];

            if (qsLogar != null)
            {
                int a = Convert.ToInt32(qsLogar);
                forcarLogin(Usuario.ObterUsuarioById(a));
            }

        }

        private void forcarLogin(Usuario usuario)
        {
            if (usuario == null)
                return;

            var u = usuario;

            FormsAuthentication.SetAuthCookie(u.NomeUsuario, true);
            Response.Redirect("~/");
        }

        private void popularLvUsuarios()
        {
            using (var ctx = new EcommerceDBEntities()) { 
                lvUsuarios.DataSource = (from u in ctx.Usuarios select u).ToList();
                lvUsuarios.DataBind();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            Usuario user = new Usuario();

            user.EmailUsuario = inpEmail.Value;
            user.NomeUsuario = inpNome.Value;
            user.SenhaUsuario = FormsAuthentication.HashPasswordForStoringInConfigFile(inpPass.Value, "SHA1");
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