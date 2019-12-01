<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerfilProduto.aspx.cs" Inherits="ecommerce.PerfilProduto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Perfil Produto | </title>
</head>
<body>
    
    <a href="" id="linkCarrinhoUsuario" target="_blank" runat="server"></a>
    <p id="NomeProdutoAuth" runat="server"></p>
    
    <form action="" method="" runat="server">
        <asp:Button id="btnAddCarrinho" Text="Adicionar no Carrinho" runat="server" OnClick="btnAddCarrinho_Click" />
        <asp:Button id="btnRemoveCarrinho" Text="Remover do Carrinho" runat="server" OnClick="btnRemoveCarrinho_Click" />
    </form>
</body>
</html>
