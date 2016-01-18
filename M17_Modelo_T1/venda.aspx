<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="venda.aspx.cs" Inherits="M17_Modelo_T1.venda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Cliente:<asp:DropDownList ID="ddCliente" runat="server">
        </asp:DropDownList>
        <br />
        Produto:<asp:DropDownList ID="ddProduto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddProduto_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        Preço:<asp:TextBox ID="tbPreco" runat="server"></asp:TextBox>
        <br />
        Quantidade:<asp:TextBox ID="tbQuantidade" runat="server"></asp:TextBox>
        <br />
        Data:<asp:TextBox ID="tbData" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Adicionar" OnClick="Button1_Click" CssClass="btn btn-danger"/>
    
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
