using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ecommerce.adm
{
    public partial class Upload : System.Web.UI.Page
    {

        private static Usuario userAuth = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Convert.ToInt32(Page.User.Identity.Name);
                userAuth = Usuario.ObterUsuarioById(id);

                if (!Page.User.Identity.IsAuthenticated)
                    Response.Redirect("../Login.aspx");

                var qsCod = Request.QueryString["cod"];
                if (qsCod != null && userAuth.getNomeNivel == "Admin")
                    PreencherNomeProduto(qsCod);
                else
                    Response.Redirect("~/");
            }

        }

        private void PreencherNomeProduto(string qsCod)
        {
            var nome = Produto.ObterProdutoByCodigo(Convert.ToInt32(qsCod)).NomeProduto;
            lblNomeProduto.Text = nome;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    //Permite imagens de no máximo 8MB
                    if (FileUploadControl.PostedFile.ContentLength < 8388608)
                    {
                        try
                        {
                            //Aqui ele vai filtrar pelo tipo de arquivo
                            if (FileUploadControl.PostedFile.ContentType == "image/jpg" ||
                                FileUploadControl.PostedFile.ContentType == "image/jpeg" ||
                                FileUploadControl.PostedFile.ContentType == "image/png" ||
                                FileUploadControl.PostedFile.ContentType == "image/gif" ||
                                FileUploadControl.PostedFile.ContentType == "image/bmp")
                            {
                                try
                                {
                                    //Obtem o  HttpFileCollection
                                    HttpFileCollection hfc = Request.Files;
                                    for (int i = 0; i < hfc.Count; i++)
                                    {
                                        HttpPostedFile hpf = hfc[i];
                                        if (hpf.ContentLength > 0)
                                        {
                                            //Pega o nome do arquivo
                                            string nome = Path.GetFileName(hpf.FileName);

                                            //Pega a extensão do arquivo
                                            string extensao = Path.GetExtension(hpf.FileName);

                                            //Gera nome novo do Arquivo
                                            var qsISBN = Request.QueryString["cod"];
                                            string filename = qsISBN;//string.Format("{0:00000000000000}", GerarID());

                                            //Caminho a onde será salvo
                                            hpf.SaveAs(Server.MapPath("~/upload/fotos/") + filename + i
                                            + extensao);

                                            //Prefixo p/ img pequena
                                            var prefixoP = "-p";
                                            //Prefixo p/ img grande
                                            var prefixoG = "-g";

                                            //pega o arquivo já carregado
                                            string pth = Server.MapPath("~/upload/fotos/")
                                            + filename + i + extensao;

                                            //Redefine altura e largura da imagem e Salva o arquivo + prefixo
                                            Redefinir.resizeImageAndSave(pth, 70, 53, prefixoP);
                                            Redefinir.resizeImageAndSave(pth, 500, 331, prefixoG);
                                        }

                                    }
                                }
                                catch (Exception ex)
                                {

                                }
                                // Mensagem se tudo ocorreu bem
                                StatusLabel.Text = "Todas imagens carregadas com sucesso!";

                            }
                            else
                            {
                                // Mensagem notifica que é permitido carregar apenas 
                                // as imagens definida la em cima.
                                StatusLabel.Text = "É permitido carregar apenas imagens!";
                            }
                        }
                        catch (Exception ex)
                        {
                            // Mensagem notifica quando ocorre erros
                            StatusLabel.Text = "O arquivo não pôde ser carregado. O seguinte erro ocorreu: " + ex.Message;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Mensagem notifica quando ocorre erros
                    StatusLabel.Text = "O arquivo não pôde ser carregado. O seguinte erro ocorreu: " + ex.Message;
                }
            }
            else
            {
                // Mensagem notifica quando imagem é superior a 8 MB
                StatusLabel.Text = "Não é permitido carregar mais do que 8 MB";
            }
        }
    }

    class Redefinir
    {
        public static string resizeImageAndSave(string imagePath, int largura,
        int altura, string prefixo)
        {
            System.Drawing.Image fullSizeImg = System.Drawing.Image.FromFile(imagePath);

            var thumbnailImg = new Bitmap(largura, altura);
            var thumbGraph = Graphics.FromImage(thumbnailImg);

            thumbGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode =
            System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            var imageRectangle = new Rectangle(0, 0, largura, altura);

            thumbGraph.DrawImage(fullSizeImg, imageRectangle);

            string targetPath = imagePath.Replace(Path.GetFileNameWithoutExtension(imagePath),
            Path.GetFileNameWithoutExtension(imagePath) + prefixo);

            thumbnailImg.Save(targetPath, System.Drawing.Imaging.ImageFormat.Jpeg);

            thumbnailImg.Dispose();

            return targetPath;
        }
    }
}