<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="NowaRezerwacja.aspx.cs" Inherits="SRS.WebForm14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="start" runat="server">
    <section>
        <p class="pNaglowek">Nowa Rezerwacja</p>
            <table class="login_table" style="text-align:center">
                <tr>
                    <td>
                        Sala: <asp:DropDownList ID="ddlSale" runat="server" DataSourceID="sdsSale" DataTextField="Nazwa" DataValueField="Id_Sala"></asp:DropDownList>
                        <asp:SqlDataSource ID="sdsSale" runat="server" ConnectionString="<%$ ConnectionStrings:SRSConnectionString %>" SelectCommand="SELECT * FROM [Sala]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        Od: 
                        <asp:TextBox ID="tbDataOd" runat="server" TextMode="Date"></asp:TextBox>
                        <asp:TextBox ID="tbCzasOd" runat="server" TextMode="Time"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTbDataOd" runat="server" ErrorMessage=" Pole wymagane " ControlToValidate="tbDataOd" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="rfvTbCzasOd" runat="server" ErrorMessage=" Pole wymagane " ControlToValidate="tbCzasOd" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Do:
                        <asp:TextBox ID="tbDataDo" runat="server" TextMode="Date"></asp:TextBox>
                        <asp:TextBox ID="tbCzasDo" runat="server" TextMode="Time"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTbDataDo" runat="server" ErrorMessage=" Pole wymagane " ControlToValidate="tbDataDo" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="rfvTbCzasDo" runat="server" ErrorMessage=" Pole wymagane " ControlToValidate="tbCzasDo" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Komentarz: <br />
                        <asp:TextBox ID="tbKomentarz" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                       <asp:Button ID="btRezerwuj" runat="server" Text="Zarezerwuj" OnClick="btRezerwuj_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CustomValidator ID="cvCzas" runat="server" ErrorMessage="Podano nieprawidłową datę lub czas</br>" OnServerValidate="cvCzas_ServerValidate"></asp:CustomValidator>
                        <asp:Label ID="lblBlad" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
     </section>
</asp:Content>
