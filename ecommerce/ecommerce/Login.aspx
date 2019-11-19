<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ecommerce.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Página de Login</title>
    <link href="css/Login.css" rel="stylesheet" />

</head>
<body>

    <ul>
    <asp:ListView id="lvUsuarios" runat="server">
        <ItemTemplate>
            <li>
               Email : <%# Eval("EmailUsuario") %><br />
               Nome  : <%# Eval("NomeUsuario") %> [<!--<span><%# DataBinder.Eval(Container.DataItem, "nivel.NomeNivel") %></span>-->]

                <a href="Login.aspx?login=<%# Eval("EmailUsuario") %>">Login</a>
            </li>
        </ItemTemplate>
    </asp:ListView>
    </ul>

    <form id="form1" runat="server">

        <h2>Cadastrar novo Usuário</h2>

        <div>
            <p>Nome</p>
            <input type="text" id="inpNome" required runat="server"/>
        </div>

        <div>
            <p>Nivel</p>
            <select id="slctNivel" runat="server">
                <option value="Cliente">Cliente</option>
                <option value="Admin">Administrador</option>
            </select>
        </div>
        
        <div>
            <p>Email</p>
            <input type="email" id="inpEmail" required runat="server"/>
        </div>

        <div>
            <p>Senha</p>
            <input type="password" id="inpPass" required runat="server"/>
        </div>

        <asp:Button Text="Cadastrar" ID="btnLogin" runat="server" OnClick="btnLogin_Click" />

        <div id="txtMenssagem" runat="server"></div>
    </form>

</body>
</html>
