<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ecommerce.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Página de Login</title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <link href="css/Login.css" rel="stylesheet" />

</head>
<body>

    <ul>
    <asp:ListView id="lvUsuarios" runat="server">
        <ItemTemplate>
            <li>
               Email : <%# Eval("EmailUsuario") %><br />
               Nome  : <%# Eval("NomeUsuario") %>[<span><%# Eval("getNomeNivel") %></span>]

                <a href="Login.aspx?login=<%# Eval("IdUsuario") %>">Login</a>
            </li>
        </ItemTemplate>
    </asp:ListView>
    </ul>

    <div class="form">
    <h2 class="formTitle">Cadastrar novo Usuário</h2>
    <form id="form1" runat="server">

        <div class="divInputs">
            
            <input type="text" id="inpNome" required runat="server"/>
            <p>Nome</p>
        </div>

        <div class="divSelect">
            <p>Nivel</p>
            <select id="slctNivel" runat="server">
                <option value="Cliente">Cliente</option>
                <option value="Admin">Administrador</option>
            </select>
        </div>
        
        <div class="divInputs">
            
            <input type="text" id="inpEmail" required runat="server"/>
            <p>Email</p>
        </div>

        <div class="divInputs">
            
            <input type="password" id="inpPass" required runat="server"/>
            <p>Senha</p>
        </div>

        <asp:Button Text="Cadastrar" ID="btnLogin" runat="server" OnClick="btnLogin_Click" />

        <div id="txtMenssagem" runat="server"></div>
    </form>
    </div>

</body>
</html>
