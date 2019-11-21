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

        /*
        public NivelUsuario nivel{ get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        */


<<<<<<< HEAD
        public static Usuario ObterUsuarioById(int id)
        {
            using (var ctx = new EcommerceDBEntities())
            {
                List<Usuario> listaUsuarios = (from u in ctx.Usuarios select u).ToList();
                var user = listaUsuarios.
                    FirstOrDefault(u => u.IdUsuario == id);
                return user;
=======
        public static Usuario ObterUsuarioById(int idUsuario)
        {
            using (var ctx = new EcommerceDBEntities())
            {
                List<Usuario> ListaUsuarios = (from u in ctx.Usuarios select u).ToList();
                var user = ListaUsuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
                return user;
>>>>>>> dbaccfbae97c862159ad140408d7cc481a4a85c6
            }
        }

        public static bool CadastrarUsuario(Usuario user)
        {
            if (user != null)
            {
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