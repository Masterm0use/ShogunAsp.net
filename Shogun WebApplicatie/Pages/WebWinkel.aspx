<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="WebWinkel.aspx.cs" Inherits="Shogun_WebApplicatie.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="server">
    <link href="../css/StyleSheet.css" rel="stylesheet" />   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
   <form runat="server">
   <div class="container">
    <div class="row">
        <div class="col-md-5">
        <asp:Panel ID="pnlShoppingCart" runat="server">
    </asp:Panel>
        <table>
            <tr>
                <td>
                    <b>TotaalStuk: </b>
                </td>
                <td>
                    <asp:Literal ID="litTotal" runat="server" Text=""></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Vat: </b>
                </td>
                <td>
                    <asp:Literal ID="litVat" runat="server" Text="" />
                </td>
            </tr>
            <tr>
            </tr>

            <tr>
                <td>
                    <b>Totaal: </b>
                </td>
                <td>
                    <asp:Literal ID="litTotalAmount" runat="server" Text="" />
                </td>
            </tr>

            <tr>
                <td>
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="/Pages/Index.aspx">Verder Winkelen</asp:LinkButton> &nbsp;&nbsp; or                     
                    <asp:Button ID="btnCheckout" runat="server" Text="Check Out" CssClass="button" Width="250px" PostBackUrl="//DOTO" />
                    <br />
                </td>
            </tr>

        </table>
    </div>
    </div>
   </div>

   </form>
</asp:Content>
