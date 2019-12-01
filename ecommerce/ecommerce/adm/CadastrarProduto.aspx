<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastrarProduto.aspx.cs" Inherits="ecommerce.adm.CadastrarProduto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastrar Produto</title>
</head>
<body>

    <form id="form1" runat="server">
        <div>

            <p>
                Nome <br />
                <input type="text" id="inpNomeProduto" name="inpNomeProduto" required runat="server"/>
            </p>

            <p>
                Peso | Volume <br />
                <input type="number" id="inpPesoVolume" name="inpPesoVolume" required runat="server"/>
            </p>

            <p>
                Preço <br />
                <input type="number" id="inpPreco" name="inpPreco" required runat="server"/>
            </p>

            <p>
                Total de Itens no Estoque <br />
                <input type="number" id="inpEstoque" name="inpEstoque" required runat="server"/>
            </p>

            <p>
                Subcategoria <br />
                <asp:DropDownList id="ddlSubcategorias" runat="server">
                </asp:DropDownList>
            </p>

            <asp:Button Text="Cadastrar" ID="btnCadastrarProduto" runat="server" runat="server" OnClick="btnCadastrarProduto_Click"/>
    
        </div>
    </form>

</body>
</html>
