<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="WebWinkel.aspx.cs" Inherits="Shogun_WebApplicatie.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
   <form runat="server">
    <div class ="container">
        <asp:Panel ID="pnlShoppingCart" runat="server">
    </asp:Panel>
        <table>
            <tr>
                <td>
                    <b>Total: </b>
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
                <td>
                    <b>Shipping: </b>
                </td>
                <td>
                    € 15
                </td>
            </tr>

            <tr>
                <td>
                    <b>Total Amount: </b>
                </td>
                <td>
                    <asp:Literal ID="litTotalAmount" runat="server" Text="" />
                </td>
            </tr>

            <tr>
                <td>
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="/Pages/Index.aspx">Continue Shopping</asp:LinkButton> &nbsp;&nbsp; or                     
                    <asp:Button ID="btnCheckout" runat="server" Text="Check Out" CssClass="button" Width="250px" PostBackUrl="//DOTO" />
                    <br />
                </td>
            </tr>

        </table>
    </div>
   </form>
</asp:Content>
