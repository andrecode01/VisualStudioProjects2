using System.Collections.Generic;
using System.Linq;

namespace ecommerce
{
    public partial class NivelUsuario
    {
        
        public static void CriarNivelUsuario(string n)
        {
            NivelUsuario nu = new NivelUsuario();
            using (var ctx = new EcommerceDBEntitiesNew())
            {
                nu.NomeNivelUsuario = n;
                ctx.NivelUsuarios.Add(nu);
                ctx.SaveChanges();
            }
        }

        public static NivelUsuario ObterNivelUsuarioByNome (string nomeNivel)
        {
            NivelUsuario nivel;

            using (var ctx = new EcommerceDBEntitiesNew())
            {
                List<NivelUsuario> nivelUsuarios = (from u in ctx.NivelUsuarios select u).ToList();
                nivel = nivelUsuarios.FirstOrDefault(j => j.NomeNivelUsuario == nomeNivel);
            }

            return nivel;
        }
        

    }
}