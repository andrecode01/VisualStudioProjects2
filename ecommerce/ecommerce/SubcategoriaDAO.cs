using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerce
{
    public partial class Subcategoria
    {

        public static List<Subcategoria> ObterSubcategorias()
        {
            using (var ctx = new EcommerceDBEntities1())
            {
                var cats = ctx.Subcategorias.ToList();
                return cats;
            }
        }

        public static void CriarCategoriasDefault()
        {
            string[] nomeCats = new string[5] { "Eletronico", "Roupa", "Infantil", "Livro", "Alimento"};

            for (int i = 0; i < nomeCats.Count(); i++)
                CriarCategorias(nomeCats[i]);
        }

        public static void CriarCategorias (string nomeCat)
        {
            Subcategoria cat = new Subcategoria();
            cat.NomeSubcategoria = nomeCat;
            using (var ctx = new EcommerceDBEntities1())
            {
                ctx.Subcategorias.Add(cat);
                ctx.SaveChanges();
            }
        }

    }
}