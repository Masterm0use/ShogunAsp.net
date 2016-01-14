<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="NieuwAccount.aspx.cs" Inherits="Shogun_WebApplicatie.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CSS" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="container">
    <div class="row">
        <div class="col-md-5">
            <h1>Mijn gegevens</h1>
            <h2>Profielgegevens</h2>
            <form class="form-horizontal" role="form" runat="server">
                <div class="form-group">
                    <label class="control-label col-sm-4" for="email">Voornaam:</label>
                    <div class="col-sm-8">
                        <asp:TextBox type="text" CssClass="form-control" ID="tbxVoornaam" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-4" for="pwd">Achternaam:</label>
                    <div class="col-sm-8">
                        <asp:TextBox type="text" CssClass="form-control" ID="tbxAchternaam" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-4">Bedrijfsnaam:</label>
                    <div class="col-sm-8">
                        <asp:TextBox type="text" CssClass="form-control" ID="tbxTelefoonnummer" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-4">Nieuwsbrief</label>
                    <div class="col-sm-8">
                        <asp:CheckBox CssClass="checkbox-inline"  ID="cbxSMSfunctie" Text="Ja, ik wil een nieuwsbrief krijgen" runat="server"></asp:CheckBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-4">Mobielnummer:</label>
                    <div class="col-sm-8">
                        <asp:TextBox type="text" CssClass="form-control" ID="tbxMobielnummer" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-4">Geboortedatum:</label>
                    <div class="col-sm-2">
                        <asp:TextBox type="text" CssClass="form-control" ID="tbxGeboortedatumDag"  runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <asp:TextBox type="text" CssClass="form-control" ID="tbxGeboortedatumMaand" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox type="text" CssClass="form-control" ID="tbxGeboortedatumJaar" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-4">Abonnement</label>
                    <div class="col-sm-8">
                        <asp:CheckBox CssClass="checkbox-inline"  ID="cbxNieuwsbrief" Text="Ja, ik wil een abonnement aanvragen" runat="server"></asp:CheckBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-4">Email:</label>
                    <div class="col-sm-8">
                        <asp:TextBox type="text" CssClass="form-control" ID="tbxEmail" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-4">Wachtwoord:</label>
                    <div class="col-sm-8">
                        <asp:TextBox type="text" CssClass="form-control" ID="tbxWachtwoord" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-4 col-sm-10">
                        <asp:Button type="submit" CssClass="btn btn-default" runat="server" Text="Bevestigen" OnClick="OnClick"/>
                    </div>
                </div>
            </form>
        </div>
    </div>
  </div>
</asp:Content>
