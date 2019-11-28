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

        public static List<Usuario> ObterUsuarios()
        {
            List<Usuario> usuarios;
            using (var ctx = new EcommerceDBEntities1())
            {
                usuarios = ctx.Usuarios.ToList();
            }
            return usuarios;
        }
  
        public static Usuario ObterUsuarioById(int id)
        {
            using (var ctx = new EcommerceDBEntities1())
            {
                List<Usuario> ListaUsuarios = (from u in ctx.Usuarios select u).ToList();
                var user = ListaUsuarios.FirstOrDefault(u => u.IdUsuario == id);
                return user;
            }
        }

        public static bool CadastrarUsuario(Usuario user)
        {
            if (user != null)
            {
                using (var ctx = new EcommerceDBEntities1())
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
                cliente.NivelUsuario = NivelUsuario.ObterNivelUsuarioByNome("Cliente");
                var senhaHashCliente = FormsAuthentication.HashPasswordForStoringInConfigFile("cliente8800", "SHA1");
                cliente.SenhaUsuario = senhaHashCliente;

                adm.EmailUsuario = "musk123@email.com";
                adm.NomeUsuario = "Elon Musk";
                adm.NivelUsuario = NivelUsuario.ObterNivelUsuarioByNome("Admin");
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