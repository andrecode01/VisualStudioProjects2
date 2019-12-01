﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GerenciarProdutos.aspx.cs" Inherits="ecommerce.adm.GerenciarProdutos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gerenciar Produtos</title>
</head>
<body>
    
    <a href="../">Ínicio</a> <hr />
    <a href="CadastrarProduto.aspx" target="_blank">Cadastrar Novo Produto</a>

    <asp:ListView id="lvGerenciarProdutos" runat="server">
        <ItemTemplate>
            <div>
                <p>#COD-<%# Eval("CodigoProduto") %> <%# Eval("NomeProduto") %></p>
                <p>Peso/Volume: <%# Eval("PesoVolumeProduto") %></p>
                <p>Preço: <%# Eval("PrecoProduto") %></p>
                <p>SubCategoria: <%# Eval("GetNomeSubcategoria") %></p>
                <p>Estoque/Disponivel[<%# Eval("EstoqueProduto") %>/<%# Eval("ItensDisponiveis") %>]</p>
                <progress value="<%# Eval("ItensDisponiveis") %>" max="<%# Eval("EstoqueProduto") %>"></progress>
                <a href="GerenciarProdutos.aspx"></a>
            </div>
        </ItemTemplate>
    </asp:ListView>

</body>
</html>