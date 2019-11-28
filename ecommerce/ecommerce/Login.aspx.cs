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
        public static bool criarBd = true;
        protected void Page_Load(object sender, EventArgs e)
        {

            //resetarBD();

            var qsLogar = Request.QueryString["login"];

            if (qsLogar != null)
            {
                int a = Convert.ToInt32(qsLogar);
                forcarLogin(Usuario.ObterUsuarioById(a));
            }

            if (!Page.IsPostBack)
            {
                popularLvUsuarios();
            }

        }

        private void resetarBD()
        {
            using (var ctx = new EcommerceDBEntities1())
            {

                while (criarBd)
                {
                    var deletarUsuarios = ctx.Database.Connection.CreateCommand();
                    var deletarNivelUsuarios = ctx.Database.Connection.CreateCommand();

                    deletarUsuarios.CommandText = "DELETE FROM Usuario";
                    deletarNivelUsuarios.CommandText = "DELETE FROM NivelUsuario";

                    ctx.Database.Connection.Open();
                    deletarUsuarios.ExecuteNonQuery();
                    deletarNivelUsuarios.ExecuteNonQuery();
                    ctx.Database.Connection.Close();
                    criarBd = false;
                }

                var qtdNiveis = ctx.NivelUsuarios.ToList().Count();
                if (qtdNiveis == 0)
                {
                    NivelUsuario.CriarNivelUsuario("Admin");
                    NivelUsuario.CriarNivelUsuario("Cliente");
                }

                var qtdUsuarios = ctx.Usuarios.ToList().Count();
                if (qtdUsuarios == 0)
                    Usuario.criarUsuariosDefault();
            }
        }

        private void forcarLogin(Usuario usuario)
        {
            if (usuario == null)
                return;

            var u = usuario;

            FormsAuthentication.SetAuthCookie(u.IdUsuario.ToString(), true);
            Response.Redirect("~/");
        }

        private void popularLvUsuarios()
        {
             
            lvUsuarios.DataSource = Usuario.ObterUsuarios();
            lvUsuarios.DataBind();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            Usuario user = new Usuario();
            user.EmailUsuario = inpEmail.Value;
            user.NomeUsuario = inpNome.Value;
            user.SenhaUsuario = FormsAuthentication.HashPasswordForStoringInConfigFile(inpPass.Value, "SHA1");

            user.NivelUsuario = NivelUsuario.ObterNivelUsuarioByNome(slctNivel.Value);

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