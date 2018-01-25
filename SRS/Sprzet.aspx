<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Sprzet.aspx.cs" Inherits="SRS.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="start" runat="server">
    <section>
        <p class="pNaglowek">Sprzęt</p>
            <table class="login_table">
                <tr>
                    <td style="text-align:center">
                        <asp:GridView ID="GWSprzet"  runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" OnRowDeleted="GWSprzet_RowDeleted" OnRowDeleting="GWSprzet_RowDeleting" OnSelectedIndexChanged="GWSprzet_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Nazwa" HeaderText="Nazwa" SortExpression="Nazwa" />
                                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                                <asp:CommandField HeaderText="Usuń" ShowDeleteButton="True" ShowHeader="True" />
                                <asp:CommandField HeaderText="Wybierz" ShowHeader="True" ShowSelectButton="True" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        <asp:Label ID="lblDeleteError" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center">
                     Nazwa:
                        <asp:TextBox ID="tbIndex" runat="server" Visible="False">-1</asp:TextBox>
                        <asp:TextBox ID="tbNazwaSprzetu" runat="server"> </asp:TextBox>
                     <asp:Button ID="btDodajSprzet" runat="server" Text="Dodaj" OnClick="btDodajSprzet_Click"/>
                     <asp:Button ID="btZmienSprzet" runat="server" Text="Zmień" OnClick="btZmienSprzet_Click"/>
                     <br />
                     
                        <asp:RequiredFieldValidator ID="rfvNazwa"  runat="server" ErrorMessage="Proszę podać nazwę" ControlToValidate="tbNazwaSprzetu"></asp:RequiredFieldValidator>
                        
                    </td>
                </tr>
            </table>
    </section>
</asp:Content>
