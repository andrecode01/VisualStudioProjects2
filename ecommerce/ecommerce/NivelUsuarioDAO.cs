using System.Collections.Generic;
using System.Linq;

namespace ecommerce
{
    public partial class NivelUsuario
    {

        public static void criarNiveisDeUsuarios()
        {

            NivelUsuario cliente = new NivelUsuario()
            {
                NomeNivelUsuario = "Cliente"
            };

            NivelUsuario adm = new NivelUsuario()
            {
                NomeNivelUsuario = "Admin"
            };

            using (var ctx = new EcommerceDBEntities())
            {
                List<NivelUsuario> nivelUsuarios = (from u in ctx.NivelUsuarios select u).ToList();
                ctx.NivelUsuarios.Add(cliente);
                ctx.NivelUsuarios.Add(adm);
                ctx.SaveChanges();
            }

        }

        public static NivelUsuario ObterNivelUsuarioByNome (string nomeNivel)
        {
            NivelUsuario nivel;

            using (var ctx = new EcommerceDBEntities())
            {
                List<NivelUsuario> nivelUsuarios = (from u in ctx.NivelUsuarios select u).ToList();
                nivel = nivelUsuarios.FirstOrDefault(j => j.NomeNivelUsuario == nomeNivel);
            }

            return nivel;
        }
        

    }
}