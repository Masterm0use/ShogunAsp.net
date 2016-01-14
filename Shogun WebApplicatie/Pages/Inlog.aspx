<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Inlog.aspx.cs" Inherits="Shogun_WebApplicatie.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="server">
    <link href="../css/Login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
     <form class="form-signin" runat="server">
        <h2 class="form-signin-heading">Log In</h2>
        <label for="inputEmail" class="sr-only">Username</label>
        <asp:TextBox ID="tbxInputUsername" runat="server" CssClass="form-control" placeholder ="Username" required="" autofocus="true"></asp:TextBox>
       <label for="inputPassword" class="sr-only">Password</label>
        <asp:TextBox ID="tbxInputPassword" runat="server" CssClass="form-control" placeholder ="Password" required="" autofocus="" TextMode="password"></asp:TextBox>
        <asp:Button ID="btnInloggen" runat="server" Text="Log In" CssClass="btn btn-lg btn-primary btn-block" type="submit" OnClick="btnInloggen_Click"/>
        <asp:Label ID="errorLabel" runat="server"></asp:Label>
     </form>
</asp:Content>
