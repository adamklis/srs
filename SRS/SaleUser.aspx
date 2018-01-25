<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="SaleUser.aspx.cs" Inherits="SRS.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="start" runat="server">
    <section>
    <p class="pNaglowek">Sale</p>
         <table class="login_table">
             <tr>
                 <td colspan="2" style="text-align:center">
                     <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_Sala" DataSourceID="sdsSale" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                         <AlternatingRowStyle BackColor="White" />
                         <Columns>
                             <asp:BoundField DataField="Id_Sala" HeaderText="Id_Sala" InsertVisible="False" ReadOnly="True" SortExpression="Id_Sala" Visible="False" />
                             <asp:BoundField DataField="Nazwa" HeaderText="Nazwa" SortExpression="Nazwa" />
                             <asp:BoundField DataField="Liczba_Miejsc" HeaderText="Liczba miejsc" SortExpression="Liczba_Miejsc" />
                             <asp:CommandField SelectText="Wybierz" ShowSelectButton="True" />
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
                     <asp:SqlDataSource ID="sdsSale" runat="server" ConnectionString="<%$ ConnectionStrings:SRSConnectionString %>" SelectCommand="SELECT * FROM [Sala]"></asp:SqlDataSource>
                 </td>
                 <td>
                     Sprzęt: <br />
                     <asp:GridView ID="GridView2" runat="server" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                         <AlternatingRowStyle BackColor="White" />
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
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SRSConnectionString %>" SelectCommand="SELECT [Nazwa_Sprzetu], [Ilosc] FROM [sala_sprzet_view] WHERE ([Id_Sala] = @Id_Sala)">
                         <SelectParameters>
                             <asp:ControlParameter ControlID="GridView1" Name="Id_Sala" PropertyName="SelectedValue" Type="Int32" />
                         </SelectParameters>
                     </asp:SqlDataSource>
                     <br />
                     Programy: <br />
                     <asp:GridView ID="GridView3" runat="server" CellPadding="4" DataSourceID="sdsProgramyList" ForeColor="#333333" GridLines="None">
                         <AlternatingRowStyle BackColor="White" />
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
                     <asp:SqlDataSource ID="sdsProgramyList" runat="server" ConnectionString="<%$ ConnectionStrings:SRSConnectionString %>" SelectCommand="SELECT [Nazwa Programu] AS Nazwa_Programu, [Ilosc] FROM [sala_progr_view] WHERE ([Id_Sala] = @Id_Sala)">
                         <SelectParameters>
                             <asp:ControlParameter ControlID="GridView1" Name="Id_Sala" PropertyName="SelectedValue" Type="Int32" />
                         </SelectParameters>
                     </asp:SqlDataSource>

                 </td>
             </tr>
         </table>
    </section>

</asp:Content>
