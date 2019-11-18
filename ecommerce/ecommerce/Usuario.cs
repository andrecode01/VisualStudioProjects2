using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;

namespace ecommerce
{
    public class Usuario
    {
        public static List<Usuario> ListaUsuarios;

        public NivelUsuario nivel{ get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }


        public static Usuario ObterUsuarioByEmail(string email)
        {
            if (ListaUsuarios == null) return null;

            var user = ListaUsuarios.
                FirstOrDefault(u => u.Email == email);
            return user;
        }

        public static bool CadastrarUsuario(Usuario user)
        {
            if (user != null)
            {
                if (ListaUsuarios == null)
                {
                    ListaUsuarios = new List<Usuario>();
                }
                ListaUsuarios.Add(user);
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

                cliente.Email = "opensador@email.com";
                cliente.Nome = "Dante Alighieri";
                cliente.nivel = NivelUsuario.ObterNivelByNomeNivel("Cliente");
                var senhaHashCliente = FormsAuthentication.HashPasswordForStoringInConfigFile("cliente8800", "SHA1");
                cliente.Senha = senhaHashCliente;

                adm.Email = "musk123@email.com";
                adm.Nome = "Elon Musk";
                adm.nivel = NivelUsuario.ObterNivelByNomeNivel("Admin");
                var senhaHashAdm = FormsAuthentication.HashPasswordForStoringInConfigFile("adm8800", "SHA1");
                adm.Senha = senhaHashAdm;

                CadastrarUsuario(cliente);
                CadastrarUsuario(adm);

            }
            catch (Exception ex)
            {
            }
        }
    }
}