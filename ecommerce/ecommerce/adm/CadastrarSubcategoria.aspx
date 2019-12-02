<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastrarSubcategoria.aspx.cs" Inherits="ecommerce.adm.CadastrarSubcategoria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastrar Subcategoria</title>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <p>Nome da Subcategoria <br />
                <input type="text" id="inpNomeCategoria" name="inpNomeCategoria" runat="server" required/>

                <asp:Button Text="Cadastrar" ID="btnCadastrar" runat="server" OnClick="btnCadastrar_Click" />
            </p>
        </div>
    </form>

</body>
</html>
