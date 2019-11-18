using System.Collections.Generic;
using System.Linq;

namespace ecommerce
{
    public class NivelUsuario
    {
        public static List<NivelUsuario> listaNivels { get; set; }

        public string NomeNivel { get; set; }

        public static void CriarListaNivel()
        {

            if (NivelUsuario.listaNivels != null)
                return;

            NivelUsuario cliente = new NivelUsuario()
            {
                NomeNivel = "Cliente"
            };

            NivelUsuario adm = new NivelUsuario()
            {
                NomeNivel = "Admin"
            };

            listaNivels = new List<NivelUsuario>();

            listaNivels.Add(cliente);
            listaNivels.Add(adm);

        }

        public static NivelUsuario ObterNivelByNomeNivel (string nomeNivel)
        {
            CriarListaNivel();

            NivelUsuario n = listaNivels.FirstOrDefault(u => u.NomeNivel == nomeNivel);

            return n;
        }

    }
}