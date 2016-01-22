<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="indexmp.aspx.cs" Inherits="M17_Modelo_T1.indexmp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--Head-->
    <title>Site modelo M17A</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--body-->
    <div class="jumbotron">
            <h1>PSI - Módulo 17A</h1>
        </div>
        <img src="./Imagens/psi3.jpg" class="img-responsive" alt="PSI" />
        <p>alunosNET.pt.vu</p>
        <div runat="server" id="div_cookies">
            Este site utiliza cookies
        </div>
</asp:Content>
