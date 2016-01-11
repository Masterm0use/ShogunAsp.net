<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Shogun_WebApplicatie.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="server">
    <link href="../css/StyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
  <div class="sidebarcontainer">
     <div class="col-xs-7 col-sm-2 sidebar-offcanvas" id="sidebar">
           <div class="list-group">
            <a href="" class="list-group-item active">Link</a>
            <a href="" class="list-group-item">Link</a>
            <a href="" class="list-group-item">Link</a>
            <a href="" class="list-group-item">Link</a>
            <a href="" class="list-group-item">Link</a>
            <a href="" class="list-group-item">Link</a>
            <a href="" class="list-group-item">Link</a>
            <a href="" class="list-group-item">Link</a>
            <a href="" class="list-group-item">Link</a>
            <a href="" class="list-group-item">Link</a>
          </div>
        </div>
       </div>
    <div class="container">
       <div class="row row-offcanvas row-offcanvas-right">
        <div class="col-xs-12 col-sm-9">
          <p class="pull-right visible-xs">
            <button type="button" class="btn btn-primary btn-xs" data-toggle="offcanvas">Toggle nav</button>
          </p>
             <div class="jumbotron">
            <h1>SHOGUN.NL</h1>
            <p>Welkom op de hoofdpagina van shogun!</p>
          </div>
            <form runat="server">
        <asp:Panel ID="pnlProducts" runat="server"></asp:Panel>
        <div class =" conatainer">
    <div style="clear: both"></div>
        </div>
            </form>
            </div>
       </div>
        <footer>
            <hr>
        <p>Mario Schipper.</p>
      </footer>
    </div>
</asp:Content>
