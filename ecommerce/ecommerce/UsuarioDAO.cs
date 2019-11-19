using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;

namespace ecommerce
{
    public partial class Usuario
    {
        public static List<Usuario> ListaUsuarios;

        public NivelUsuario nivel{ get; set; }
        /*
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        */


        public static Usuario ObterUsuarioByEmail(string email)
        {
            if (ListaUsuarios == null) return null;

            var user = ListaUsuarios.
                FirstOrDefault(u => u.EmailUsuario == email);
            return user;
        }

        public static bool CadastrarUsuario(Usuario user)
        {
            if (user != null)
            {
                /*if (ListaUsuarios == null)
                {
                    ListaUsuarios = new List<Usuario>();
                }*/
                using (var ctx = new EcommerceDBEntities())
                {
                    ctx.Usuarios.Add(user);
                    ctx.SaveChanges();
                }
                return true;
            }
            return false;
        }

        public static void criarUsuariosDefault()
        {
            try
            {

                Usuario adm = new Usuario();
                Usuario cliente = new Usuario();

                cliente.EmailUsuario = "opensador@email.com";
                cliente.NomeUsuario = "Dante Alighieri";
                //cliente.nivel = NivelUsuario.ObterNivelByNomeNivel("Cliente");
                var senhaHashCliente = FormsAuthentication.HashPasswordForStoringInConfigFile("cliente8800", "SHA1");
                cliente.SenhaUsuario = senhaHashCliente;

                adm.EmailUsuario = "musk123@email.com";
                adm.NomeUsuario = "Elon Musk";
                //adm.nivel = NivelUsuario.ObterNivelByNomeNivel("Admin");
                var senhaHashAdm = FormsAuthentication.HashPasswordForStoringInConfigFile("adm8800", "SHA1");
                adm.SenhaUsuario = senhaHashAdm;

                CadastrarUsuario(cliente);
                CadastrarUsuario(adm);

            }
            catch (Exception ex)
            {
            }
        }
    }
}