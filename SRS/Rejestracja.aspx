<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Rejestracja.aspx.cs" Inherits="SRS.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="start" runat="server">
    <section>
        <p class="pNaglowek">Rejestracja:</p>
        <table class="login_table">
            <tr>
                <td class="td_field">Login: <asp:TextBox ID="tbLogin" runat="server" MaxLength="50"></asp:TextBox></td>
                <td class="tdRFV"><asp:RequiredFieldValidator ID="LoginRFV" ForeColor="Red" runat="server" ErrorMessage="Proszę podać login" ControlToValidate="tbLogin" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="LoginCV" ForeColor="Red" runat="server" ErrorMessage="Użytkownik już istnieje" ControlToValidate="tbLogin" Display="Dynamic" OnServerValidate="LoginCV_ServerValidate"></asp:CustomValidator></td>
            </tr>
            <tr>
                <td class="td_field">Hasło: <asp:TextBox ID="tbHaslo" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox></td>
                <td class="tdRFV"><asp:RequiredFieldValidator ID="HasloRFV" ForeColor="Red" runat="server" ErrorMessage="Proszę podać hasło" ControlToValidate="tbHaslo"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="td_field">Nazwisko: <asp:TextBox ID="tbNazwisko" runat="server" MaxLength="50"></asp:TextBox></td>
                <td class="tdRFV"><asp:RequiredFieldValidator ID="NazwiskoRFV" ForeColor="Red" runat="server" ErrorMessage="Proszę podać nazwisko" ControlToValidate="tbNazwisko"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="td_field">Imię: <asp:TextBox ID="tbImie" runat="server" MaxLength="50"></asp:TextBox></td>
                <td class="tdRFV"><asp:RequiredFieldValidator ID="ImieRFV" ForeColor="Red" runat="server" ErrorMessage="Proszę podać imię" ControlToValidate="tbImie"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="td_field">Kontakt: <asp:TextBox ID="tbKontakt" runat="server" MaxLength="50"></asp:TextBox></td>
                <td class="tdRFV"><asp:RequiredFieldValidator ID="KontaktRFV" ForeColor="Red" runat="server" ErrorMessage="Proszę podać dane kontaktowe" ControlToValidate="tbKontakt"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="td_field">Rola: <asp:TextBox ID="tbRola" runat="server" MaxLength="50"></asp:TextBox></td>
                <td class="tdRFV"><asp:RequiredFieldValidator ID="RolaRFV" ForeColor="Red" runat="server" ErrorMessage="Proszę podać pełniną funkcję" ControlToValidate="tbRola"></asp:RequiredFieldValidator></td>
            </tr>
            
            <tr>
                <td class="td_field"><asp:Button ID="btZaloguj" runat="server" Text="Zarejestruj" OnClick="btZaloguj_Click" /></td>
                <td></td>
            </tr>
        </table>
    </section>
</asp:Content>
