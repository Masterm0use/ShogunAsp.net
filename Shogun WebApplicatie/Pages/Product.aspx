<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Shogun_WebApplicatie.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="server">
    <link href="../css/StyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <form runat="server">
       <div class="conatainer">
         <table>
        <tr>
            <td rowspan="4" style="width: 400px">
                <asp:Image ID="imgProduct" runat="server" CssClass="detailsImage" />
            </td>
            <td style="width: 400px;">
                <h2>
                    <asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDescription" runat="server" CssClass="detailsDescription"></asp:Label>
            </td>
            <td style="margin-left: 10px">
                <asp:Label ID="lblPrice" runat="server" CssClass="detailsPrice"></asp:Label><br />
                Quantity:<asp:DropDownList ID="ddlAmount" runat="server"></asp:DropDownList><br />
                <asp:Button ID="btnAdd" runat="server" CssClass="button" OnClick="btnAdd_OnClick" Text="Add Product" />
                <br />
                
                <asp:Label ID="lblResult" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Product No:
                <br />
                <asp:Label ID="lblItemNr" runat="server" Style="font-style: italic"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;<asp:Label ID="lblAvailable" runat="server" CssClass="productPrice">Available!</asp:Label>
            </td>
        </tr>
    </table>
       </div>
    </form>
</asp:Content>
