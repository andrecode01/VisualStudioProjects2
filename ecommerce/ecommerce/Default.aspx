<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ecommerce.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
</head>
<body>

    <form runat="server">
    <div style="float: right;">
            <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutText="Sair"/>
    </div>
    </form>

    <div style="text-align: center;">
        
     Bem-Vindo, <u><asp:LoginName ID="LoginName1" runat="server" /></u> 
     <h1>E-Commerce</h1>
    </div>
</body>
</html>
