<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ecommerce.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="css/Default.css" rel="stylesheet" />

    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.11.2/css/all.css" rel="stylesheet" />
</head>
<body>

    <form runat="server">
    <div style="float: right;">
            <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutText="Sair"/>
    </div>
    </form>

    <div style="text-align: center;">
        
     Bem-Vindo, <u id="NomeAuth" runat="server"></u>
        [<span  id="NomeNivelAuth" runat="server"></span>]
     <h1>E-Commerce</h1>
    </div>

    <a  id="btnGerenciarProdutos" 
        href="/adm/GerenciarProdutos.aspx"  
        target="_blank"
        runat="server">
        Gerenciar Produtos
    </a>

    <nav>
        <div class="car">
            <p>Carrinho(<span id="qtdCar" runat="server">*</span>)</p>
            <p>R$ <span id="totalRsCar" runat="server">*</span></p>
        </div>
    </nav>
    <p>
        Filtrar por: <br />
        <asp:ListView ID="lvFiltro" runat="server">
            <ItemTemplate>
                <a href="Default.aspx?filtro=<%# Eval("IdSubcategoria") %>" >#<%# Eval("NomeSubcategoria") %></a>
            </ItemTemplate>
        </asp:ListView>
    </p>
    <div class="p-container">
        <asp:ListView id="lvProdutos" runat="server">
            <ItemTemplate>
                <div class="p-item" onclick="window.open('PerfilProduto.aspx?cod=<%#Eval("CodigoProduto") %>')" target="_blank">
                    <p><%# Eval("NomeProduto") %></p>
                    <p><%# Eval("PrecoProduto") %></p>
                    <p><%# Eval("EstoqueProduto") %></p>
                    <p>#<%# Eval("GetNomeSubcategoria") %></p>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <p id="teste" runat="server"></p>

</body>
</html>
