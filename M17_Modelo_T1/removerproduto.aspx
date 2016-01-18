<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="removerproduto.aspx.cs" Inherits="M17_Modelo_T1.removerproduto" %>

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
    <h1>Remover produto</h1>
        <asp:Label ID="lbId" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lbDesc" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lbPreco" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lbQuant" runat="server" Text=""></asp:Label>
        <br />
        <asp:Image ID="Image1" runat="server" />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Remover" CssClass="btn btn-danger" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Voltar" CssClass="btn btn-link" OnClick="Button2_Click" />
        <br />
    </div>
    </form>
</body>
</html>
