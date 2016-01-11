<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Inlog.aspx.cs" Inherits="Shogun_WebApplicatie.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="server">
    <link href="../css/Login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
     <form class="form-signin" runat="server">
         <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate1"></asp:Login>
     </form>
</asp:Content>
