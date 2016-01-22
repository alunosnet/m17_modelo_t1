<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="clientesmp.aspx.cs" Inherits="M17_Modelo_T1.clientesmp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Clientes</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Adicionar Cliente</h1>
    Nome:<asp:TextBox ID="tbNome" runat="server"></asp:TextBox>
        <br />
        Morada:<asp:TextBox ID="tbMorada" runat="server"></asp:TextBox>
        <br />
        Código Postal:<asp:TextBox ID="tbCP" runat="server"></asp:TextBox>
        <br />
        Data Nascimento:<asp:TextBox ID="tbDataNascimento" runat="server"></asp:TextBox>
        <br />
        Email:<asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Adicionar" CssClass="btn btn-info" />
        <br />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <h1>Lista de clientes</h1>
        
    
</asp:Content>
