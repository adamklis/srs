<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Rezerwacje.aspx.cs" Inherits="SRS.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="start" runat="server">
    <section>
        <p class="pNaglowek">Rezerwacje</p>
            <table class="login_table">
                <tr>
                    <td>
                        <asp:GridView ID="gwRezerwacje" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_Rezerwacja" DataSourceID="sdsRezerwacje" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" OnRowDeleting="gwRezerwacje_RowDeleting">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Id_Rezerwacja" HeaderText="Id_Rezerwacja" ReadOnly="True" SortExpression="Id_Rezerwacja" />
                                <asp:BoundField DataField="Nazwa" HeaderText="Nazwa" SortExpression="Nazwa" />
                                <asp:BoundField DataField="Nazwisko" HeaderText="Nazwisko" SortExpression="Nazwisko" />
                                <asp:BoundField DataField="Imie" HeaderText="Imie" SortExpression="Imie" />
                                <asp:BoundField DataField="Kontakt" HeaderText="Kontakt" SortExpression="Kontakt" />
                                <asp:BoundField DataField="Czas_Od" HeaderText="Czas_Od" SortExpression="Czas_Od" />
                                <asp:BoundField DataField="Czas_Do" HeaderText="Czas_Do" SortExpression="Czas_Do" />
                                <asp:BoundField DataField="Komentarz" HeaderText="Komentarz" SortExpression="Komentarz" />
                                <asp:BoundField DataField="Id_Uzytkownik" HeaderText="Id_Uzytkownik" SortExpression="Id_Uzytkownik" Visible="False" />
                                <asp:CommandField DeleteText="Usuń" ShowDeleteButton="True" />
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
                        <asp:SqlDataSource ID="sdsRezerwacje" runat="server" ConnectionString="<%$ ConnectionStrings:SRSConnectionString %>" SelectCommand="SELECT * FROM [rezerwacje_view]"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        </section>
</asp:Content>
