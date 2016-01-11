<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ManagmentProduct.aspx.cs" Inherits="Shogun_WebApplicatie.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <form runat="server">
     <div class="container">
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <H1>Nieuw product toevoegen:</H1>
                     <div class="form-group">
                        <label for="IDproduct">Id van product:</label>
                          <asp:TextBox ID="txtID" runat="server" CssClass="input-group"></asp:TextBox>
                    </div>
                     <div class="form-group">
                        <label for="NameProduct">Naam product:</label>
                          <asp:TextBox ID="txtName" runat="server" CssClass="input-group"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="cat2Product">Naam Hoofdcategorie:</label>
                          <asp:DropDownList ID="ddlCategorieParanet" CssClass="dropdown" OnSelectedIndexChanged="ddlCategorieParanet_OnSelectedIndexChanged" AutoPostBack="true" EnableViewState="true" runat="server">
                           </asp:DropDownList>
                        </div>
                    <div class="form-group">
                        <label for="catProduct">Naam categorie:</label>
                          <asp:DropDownList ID="ddlCategorie" CssClass="dropdown" OnSelectedIndexChanged="ddlCategorie_OnSelectedIndexChanged" AutoPostBack="true" EnableViewState="true" runat="server">
                           </asp:DropDownList>
                    </div>
                     <div class="form-group">
                        <label for="NameProduct">Beschikbaar:</label>
                          <asp:TextBox ID="txtBeschikbaar" runat="server" CssClass="input-group"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="Priceproduct">Prijs product::</label>
                          <asp:TextBox ID="txtPrice" runat="server" CssClass="input-group"></asp:TextBox>
                        </div>
                    <div class="form-group">
                        <label for="ImageProduct">Image:</label>
                          <asp:DropDownList ID="ddlImage" CssClass="dropdown"  Width="270" runat="server">
                           </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="BeschrijvingProduct">Beschrijving product:</label>
                          <asp:TextBox ID="txtDescription" runat="server" Height="74px" TextMode="MultiLine" CssClass="input-group"></asp:TextBox>
                    </div>
                        <p>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_OnClick" CssClass="button" />
                </p>
                <p>
                    <asp:Label ID="lblResult" runat="server"></asp:Label>
                </p>
                </div>
            </div>
     </div>
    </form>
    
</asp:Content>
