<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SRS.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="start" runat="server">
    <section>
        <p class="pNaglowek">Logowanie:</p>
        <table class="login_table">
            <tr>
                <td class="td_field">Login: <asp:TextBox ID="tbLogin" runat="server" MaxLength="50"></asp:TextBox></td>
                <td class="tdRFV"><asp:RequiredFieldValidator ID="LoginRFV" ForeColor="Red" runat="server" ErrorMessage="Proszę podać login" ControlToValidate="tbLogin"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="td_field">Hasło: <asp:TextBox ID="tbHaslo" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox></td>
                <td class="tdRFV"><asp:RequiredFieldValidator ID="HasloRFV" ForeColor="Red" runat="server" ErrorMessage="Proszę podać hasło" ControlToValidate="tbLogin"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="td_field"><asp:Button ID="btZaloguj" runat="server" Text="Zaloguj" OnClick="btZaloguj_Click" /></td>
                <td class="tdRFV">
                    <asp:CustomValidator ID="LoginCV" ForeColor="Red" runat="server" ErrorMessage="Niepoprawna nazwa użytkownika lub hasło!" OnServerValidate="LoginCV_ServerValidate"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td>
                Login testowy: admin <br/>
                Hasło: zaq1@WSX
                </td>
            </tr>
        </table>
    </section>
</asp:Content>
