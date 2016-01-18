<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editarproduto.aspx.cs" Inherits="M17_Modelo_T1.editarproduto" %>

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
    
        <asp:Label ID="lbId" runat="server" Text=""></asp:Label>
    
        <br />
        Descrição:<asp:TextBox ID="tbDesc" runat="server"></asp:TextBox>
        <br />
        Preço:<asp:TextBox ID="tbPreco" runat="server"></asp:TextBox>
        <br />
        Quantidade:<asp:TextBox ID="tbQuant" runat="server"></asp:TextBox>
        <br />
        <asp:Image ID="Image1" runat="server" />
        <br />
        Imagem: <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn btn-file"/>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Atualizar" CssClass="btn btn-danger" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Voltar" CssClass="btn btn-link" OnClick="Button2_Click"/>
    
    </div>
    </form>
</body>
</html>
