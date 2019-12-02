using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerce.adm
{
    public partial class CadastrarProduto : System.Web.UI.Page
    {

        private static Usuario userAuth = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                popularDdlSubcategorias(Subcategoria.ObterSubcategorias(), null);

                int id = Convert.ToInt32(Page.User.Identity.Name);
                userAuth = Usuario.ObterUsuarioById(id);

                if (!Page.User.Identity.IsAuthenticated)
                    Response.Redirect("../Login.aspx");

                if (userAuth.getNomeNivel != "Admin")
                    Response.Redirect("../Default.aspx");

                var codAlt = Page.Request.QueryString["codalt"];
                if (codAlt != null)
                {
                    var p = Produto.ObterProdutoByCodigo(Convert.ToInt32(codAlt));
                    if(p != null)
                        preencherCampos(p);
                }
            }

        }

        private void preencherCampos(Produto p)
        {
            inpNomeProduto.Value = p.NomeProduto;
            inpPesoVolume.Value = Convert.ToString(Convert.ToInt32(p.PesoVolumeProduto));
            inpEstoque.Value = Convert.ToString(p.EstoqueProduto);
            inpEstoque.Disabled = true;
            inpPreco.Value = Convert.ToString(Convert.ToInt32(p.PrecoProduto));

            Subcategoria scat = Subcategoria.ObterSubcategorias().FirstOrDefault(sc => sc.NomeSubcategoria == p.GetNomeSubcategoria);

            popularDdlSubcategorias(Subcategoria.ObterSubcategorias(), scat);

            btnCadastrarProduto.Text = "Alterar";
        }

        private void popularDdlSubcategorias(List<Subcategoria> cats, Subcategoria cat)
        {
            if (cat == null)
            {
                ddlSubcategorias.DataSource =
                    cats.OrderBy(item => item.NomeSubcategoria).ToList();
                ddlSubcategorias.DataTextField = "NomeSubcategoria";
                ddlSubcategorias.DataValueField = "IdSubcategoria";
                ddlSubcategorias.DataBind();
            }
            else
            {
                Subcategoria aux = cats[0];

                for (int i = 0; i < cats.Count(); i++)
                    if(cats[i].IdSubcategoria == cat.IdSubcategoria)
                    {
                        cats[0] = cats[i];
                        cats[i] = aux;
                    }
                ddlSubcategorias.DataSource = cats;
                ddlSubcategorias.DataTextField = "NomeSubcategoria";
                ddlSubcategorias.DataValueField = "IdSubcategoria";
                ddlSubcategorias.DataBind();
            }
        }

        protected void btnCadastrarProduto_Click(object sender, EventArgs e)
        {

            Produto p = new Produto();

            var codAlt = Page.Request.QueryString["codalt"];
            var pAlt = Produto.ObterProdutoByCodigo(Convert.ToInt32(codAlt));

            if (codAlt != null)
            {
                if (pAlt != null)
                {
                    p.NomeProduto = inpNomeProduto.Value;
                    p.PesoVolumeProduto = Convert.ToDecimal(inpPesoVolume.Value);
                    p.PrecoProduto = Convert.ToDecimal(inpPreco.Value);
                    p.Produto_IdSubcategoria = Subcategoria
                    .ObterSubcategorias()
                    .FirstOrDefault(s => s.IdSubcategoria == Convert.ToInt32(ddlSubcategorias.SelectedValue))
                    .IdSubcategoria;

                    alterarDadosProduto(Convert.ToInt32(codAlt), p);
                }
            }
            else
            {
                p.NomeProduto = inpNomeProduto.Value;
                p.PesoVolumeProduto = Convert.ToDecimal(inpPesoVolume.Value);
                p.PrecoProduto = Convert.ToDecimal(inpPreco.Value);
                p.EstoqueProduto = 0;
                p.Produto_IdSubcategoria = Subcategoria
                    .ObterSubcategorias()
                    .FirstOrDefault(s => s.IdSubcategoria == Convert.ToInt32(ddlSubcategorias.SelectedValue))
                    .IdSubcategoria;
                var qtdEstoque = Convert.ToInt32(inpEstoque.Value);

                Produto.CadastrarProduto(p, qtdEstoque);
            }
        }

        private void alterarDadosProduto(int codP, Produto p)
        {
            using (var ctx = new EcommerceDBEntities1())
            {
                ctx.Produtoes.FirstOrDefault(pd => pd.CodigoProduto == codP).NomeProduto = p.NomeProduto;
                ctx.Produtoes.FirstOrDefault(pd => pd.CodigoProduto == codP).PesoVolumeProduto = p.PesoVolumeProduto;
                ctx.Produtoes.FirstOrDefault(pd => pd.CodigoProduto == codP).PrecoProduto = p.PrecoProduto;
                ctx.Produtoes.FirstOrDefault(pd => pd.CodigoProduto == codP).Produto_IdSubcategoria = p.Produto_IdSubcategoria;
                ctx.SaveChanges();
            }
        }
    }
}