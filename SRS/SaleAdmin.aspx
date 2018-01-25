<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="SaleAdmin.aspx.cs" Inherits="SRS.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="start" runat="server">
    <section>
    <p class="pNaglowek">Sale</p>
         <table class="login_table">
             <tr>
                 <td colspan="2" style="text-align:center">
                     <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_Sala" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleted="GridView1_RowDeleted">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Nazwa" HeaderText="Nazwa" SortExpression="Nazwa" />
                            <asp:BoundField DataField="Liczba_Miejsc" HeaderText="Liczba miejsc" SortExpression="Liczba_Miejsc" />
                            <asp:CommandField ShowSelectButton="True" SelectText="Wybierz" EditText="Zmień" DeleteText="Usuń" ShowDeleteButton="True" ShowEditButton="True" />
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
                     <asp:Label ID="lblDeleteError"  runat="server" Text=""></asp:Label>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SRSConnectionString %>" DeleteCommand="DELETE FROM [Sala] WHERE [Id_Sala] = @Id_Sala" InsertCommand="INSERT INTO [Sala] ([Nazwa], [Liczba_Miejsc]) VALUES (@Nazwa, @Liczba_Miejsc)" SelectCommand="SELECT * FROM [Sala]" UpdateCommand="UPDATE [Sala] SET [Nazwa] = @Nazwa, [Liczba_Miejsc] = @Liczba_Miejsc WHERE [Id_Sala] = @Id_Sala">
                        <DeleteParameters>
                            <asp:Parameter Name="Id_Sala" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Nazwa" Type="String" />
                            <asp:Parameter Name="Liczba_Miejsc" Type="Int32" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Nazwa" Type="String" />
                            <asp:Parameter Name="Liczba_Miejsc" Type="Int32" />
                            <asp:Parameter Name="Id_Sala" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                 </td>
             </tr>
             <tr>
                 <td colspan="2" style="text-align:center">
                     Nazwa sali:<asp:TextBox ID="tbNazwaSali" runat="server"> </asp:TextBox>
                     Liczba miejsc:<asp:TextBox ID="tbLiczbaMiejsc" runat="server">0</asp:TextBox>
                     <asp:Button ID="BTdodajSale" runat="server" Text="Dodaj" OnClick="BTdodajSale_Click" />
                     <br />
                     <asp:RequiredFieldValidator ID="rfvLiczbaMiejsc"  runat="server" ErrorMessage="Proszę podać liczbę miejsc" ControlToValidate="tbLiczbaMiejsc"></asp:RequiredFieldValidator>
                     <asp:RangeValidator ID="rvLiczbaMiejsc" runat="server" ErrorMessage="Nieprawidłowa wartość" MinimumValue="0" MaximumValue="500" Type="Integer" ControlToValidate="TbIlosc" Display="Dynamic"></asp:RangeValidator>

                     <br />
                     <br />
                 </td>
             </tr>
            <tr>
                
                <td>
                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="programyGrid" ForeColor="#333333" GridLines="None" OnRowDeleting="GridView2_RowDeleting" HorizontalAlign="Center">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Nazwa Sali" HeaderText="Nazwa Sali" SortExpression="Nazwa Sali" />
                            <asp:BoundField DataField="Nazwa Programu" HeaderText="Nazwa Programu" SortExpression="Nazwa Programu" />
                            <asp:BoundField DataField="Ilosc" HeaderText="Ilosc" SortExpression="Ilosc" />
                            <asp:BoundField DataField="Id_Sala" HeaderText="Id_Sala" SortExpression="Id_Sala" />
                            <asp:BoundField DataField="Id_Oprogramowanie" HeaderText="Id_Oprogramowanie" SortExpression="Id_Oprogramowanie" />
                            <asp:CommandField ShowDeleteButton="True" DeleteText="Usuń" />
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
                    <asp:SqlDataSource ID="programyGrid" runat="server" ConnectionString="<%$ ConnectionStrings:SRSConnectionString %>" DeleteCommand="DELETE FROM Sale_Oprogramowanie WHERE Id_Oprogramowanie=@Id_Oprogramowanie" SelectCommand="SELECT * FROM [sala_progr_view] WHERE ([Id_Sala] = @Id_Sala)">
                        <DeleteParameters>
                            <asp:Parameter Name="Id_Oprogramowanie" Type="Int32" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="GridView1" Name="Id_Sala" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="sprzetGrid" ForeColor="#333333" GridLines="None" OnRowDeleting="GridView3_RowDeleting" HorizontalAlign="Center">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Nazwa_Sali" HeaderText="Nazwa_Sali" SortExpression="Nazwa_Sali" />
                            <asp:BoundField DataField="Nazwa_Sprzetu" HeaderText="Nazwa_Sprzetu" SortExpression="Nazwa_Sprzetu" />
                            <asp:BoundField DataField="Ilosc" HeaderText="Ilość" SortExpression="Ilosc" />
                            <asp:BoundField DataField="Id_Sala" HeaderText="Id_Sala" SortExpression="Id_Sala" />
                            <asp:BoundField DataField="Id_Sprzet" HeaderText="Id_Sprzet" SortExpression="Id_Sprzet" />
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
                    <asp:SqlDataSource ID="sprzetGrid" runat="server" ConnectionString="<%$ ConnectionStrings:SRSConnectionString %>" SelectCommand="SELECT * FROM [sala_sprzet_view] WHERE ([Id_Sala] = @Id_Sala)" DeleteCommand="DELETE FROM Sale_Sprzet">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="GridView1" Name="Id_Sala" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
             <tr>
                 <td style="text-align:center">
                     <asp:Label ID="LblNazwa" runat="server" Text="Nazwa programu: "></asp:Label>    <asp:DropDownList ID="DDLProgram" runat="server" DataSourceID="programyDropDown" DataTextField="Nazwa" DataValueField="Id_Oprogramowanie"></asp:DropDownList>
                     <br />
                     <asp:Label ID="lblIlosc" runat="server" Text="Ilość:"></asp:Label> <asp:TextBox ID="TbIlosc" runat="server" MaxLength="3">0</asp:TextBox>
                     <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Nieprawidłowa wartość" MinimumValue="0" MaximumValue="500" Type="Integer" ControlToValidate="TbIlosc" Display="Dynamic"></asp:RangeValidator>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Pole wymagane" Display="Dynamic" ControlToValidate="TbIlosc"></asp:RequiredFieldValidator>
                     <br />
                     <asp:Button ID="BtDodaj" runat="server" Text="Dodaj" OnClick="BtDodaj_Click" />
                     <asp:SqlDataSource ID="programyDropDown" runat="server" ConnectionString="<%$ ConnectionStrings:SRSConnectionString %>" SelectCommand="SELECT * FROM [Oprogramowanie] ORDER BY [Nazwa]"></asp:SqlDataSource>
                 </td>
                 <td style="text-align:center">
                     <asp:Label ID="lblNazwaSprzet" runat="server" Text="Nazwa sprzętu: "></asp:Label>    <asp:DropDownList ID="DDLSprzet" runat="server" DataSourceID="sprzetDropDown" DataTextField="Nazwa" DataValueField="Id_Sprzet"></asp:DropDownList>
                     <asp:SqlDataSource ID="sprzetDropDown" runat="server" ConnectionString="<%$ ConnectionStrings:SRSConnectionString %>" SelectCommand="SELECT * FROM [Sprzet] ORDER BY [Nazwa]"></asp:SqlDataSource>
                     <br />
                     <asp:Label ID="lblIloscSprzet" runat="server" Text="Ilość:"></asp:Label> <asp:TextBox ID="TbIloscSprzet" runat="server" MaxLength="3">0</asp:TextBox>
                     <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Nieprawidłowa wartość" MinimumValue="0" MaximumValue="500" Type="Integer" ControlToValidate="TbIloscSprzet" Display="Dynamic"></asp:RangeValidator>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Pole wymagane" Display="Dynamic" ControlToValidate="TbIloscSprzet"></asp:RequiredFieldValidator>
                     <br />
                     <asp:Button ID="BtDodajSprzet" runat="server" Text="Dodaj" OnClick="BtDodajSprzet_Click" />
                     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SRSConnectionString %>" SelectCommand="SELECT * FROM [Oprogramowanie] ORDER BY [Nazwa]"></asp:SqlDataSource>
                 </td>

             </tr>
         </table>
    </section>
</asp:Content>
