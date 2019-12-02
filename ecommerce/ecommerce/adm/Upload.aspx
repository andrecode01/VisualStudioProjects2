<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="ecommerce.adm.Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upload de imagens</title>
</head>
<body>
    <h1>Gerenciamento de Imagens</h1>
    <form id="form1" runat="server">
        <div>
            <p>
                Livro:
                <asp:Label Text="" runat="server" ID="lblNomeProduto" />
            </p>
            <br />
            <p>
                <asp:FileUpload ID="FileUploadControl" runat="server" 
                    AllowMultiple="true" />
            </p>
            <p>
                <asp:Button Text="Carregar Imagens" 
                    id="btnUpload" 
                    runat="server"
                    OnClick="btnUpload_Click"/>
            </p>
            <p>
                <asp:Label Text="" runat="server" ID="StatusLabel" />
            </p>
        </div>
    </form>
</body>
</html>
