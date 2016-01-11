<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="produtos.aspx.cs" Inherits="M17_Modelo_T1.produtos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/jquery-1.11.3.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Descrição:<asp:TextBox ID="tbDesc" runat="server"></asp:TextBox>
        <br />
        Quantidade:<asp:TextBox ID="tbQuant" runat="server"></asp:TextBox>
        <br />
        Preço:<asp:TextBox ID="tbPreco" runat="server"></asp:TextBox>
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Adicionar" cssClass="btn btn-info" OnClick="Button1_Click"/>
        <br />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" Class="table">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
