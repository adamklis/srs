<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Uzytkownicy.aspx.cs" Inherits="SRS.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="start" runat="server">
    <section>
          <p class="pNaglowek">Użytkownicy</p>
        <table class="login_table">
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id_Uzytkownik" DataSourceID="userDataSource" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Nazwisko" HeaderText="Nazwisko" SortExpression="Nazwisko" />
                <asp:BoundField DataField="Imie" HeaderText="Imie" SortExpression="Imie" />
                <asp:BoundField DataField="Kontakt" HeaderText="Kontakt" SortExpression="Kontakt" />
                <asp:BoundField DataField="Rola" HeaderText="Rola" SortExpression="Rola" />
                <asp:BoundField DataField="Login" HeaderText="Login" SortExpression="Login" />
                <asp:BoundField DataField="Uprawnienia" HeaderText="Uprawnienia" SortExpression="Uprawnienia" />
                <asp:CommandField HeaderText="Wybierz" SelectText="Wybierz" ShowSelectButton="True" />
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
                </td>
                <td>
                    <asp:FormView ID="FormView1" runat="server" DataKeyNames="Id_Uzytkownik" DataSourceID="userFormDataSource" OnItemUpdating="FormView1_ItemUpdating" OnPageIndexChanging="FormView1_PageIndexChanging" CellPadding="4" ForeColor="#333333" OnItemInserting="FormView1_ItemInserting" OnItemDeleted="FormView1_ItemDeleted">
            <EditItemTemplate>
                Nazwisko:
                <asp:TextBox ID="NazwiskoTextBox" runat="server" Text='<%# Bind("Nazwisko") %>' />
                <br />
                Imie:
                <asp:TextBox ID="ImieTextBox" runat="server" Text='<%# Bind("Imie") %>' />
                <br />
                Kontakt:
                <asp:TextBox ID="KontaktTextBox" runat="server" Text='<%# Bind("Kontakt") %>' />
                <br />
                Rola:
                <asp:TextBox ID="RolaTextBox" runat="server" Text='<%# Bind("Rola") %>' />
                <br />
                Login:
                <asp:TextBox ID="LoginTextBox" runat="server" Text='<%# Bind("Login") %>' />
                <br />
                Haslo:
                <asp:TextBox ID="HasloTextBox" runat="server" Text='<%# Bind("Haslo") %>' TextMode="Password" />
                <br />
                Uprawnienia:
                <asp:TextBox ID="UprawnieniaTextBox" runat="server" Text='<%# Bind("Uprawnienia") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </EditItemTemplate>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <InsertItemTemplate>
                Nazwisko:
                <asp:TextBox ID="NazwiskoTextBox" runat="server" Text='<%# Bind("Nazwisko") %>' />
                <br />
                Imie:
                <asp:TextBox ID="ImieTextBox" runat="server" Text='<%# Bind("Imie") %>' />
                <br />
                Kontakt:
                <asp:TextBox ID="KontaktTextBox" runat="server" Text='<%# Bind("Kontakt") %>' />
                <br />
                Rola:
                <asp:TextBox ID="RolaTextBox" runat="server" Text='<%# Bind("Rola") %>' />
                <br />
                Login:
                <asp:TextBox ID="LoginTextBox" runat="server" Text='<%# Bind("Login") %>' />
                <br />
                Haslo:
                <asp:TextBox ID="HasloTextBox" runat="server" Text='<%# Bind("Haslo") %>' />
                <br />
                Uprawnienia:
                <asp:TextBox ID="UprawnieniaTextBox" runat="server" Text='<%# Bind("Uprawnienia") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                Nazwisko:
                <asp:Label ID="NazwiskoLabel" runat="server" Text='<%# Bind("Nazwisko") %>' />
                <br />
                Imie:
                <asp:Label ID="ImieLabel" runat="server" Text='<%# Bind("Imie") %>' />
                <br />
                Kontakt:
                <asp:Label ID="KontaktLabel" runat="server" Text='<%# Bind("Kontakt") %>' />
                <br />
                Rola:
                <asp:Label ID="RolaLabel" runat="server" Text='<%# Bind("Rola") %>' />
                <br />
                Login:
                <asp:Label ID="LoginLabel" runat="server" Text='<%# Bind("Login") %>' />
                <br />
                Uprawnienia:
                <asp:Label ID="UprawnieniaLabel" runat="server" Text='<%# Bind("Uprawnienia") %>' />
                <br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Zmień" />
                &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Usuń" />
                &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="Nowy" />
            </ItemTemplate>
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
          </asp:FormView>
                    <asp:Label ID="lblDeleteError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
          <asp:SqlDataSource ID="userFormDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:SRSConnectionString %>" DeleteCommand="DELETE FROM [Uzytkownik] WHERE [Id_Uzytkownik] = @Id_Uzytkownik" InsertCommand="INSERT INTO [Uzytkownik] ([Nazwisko], [Imie], [Kontakt], [Rola], [Login], [Haslo], [Uprawnienia]) VALUES (@Nazwisko, @Imie, @Kontakt, @Rola, @Login, @Haslo, @Uprawnienia)" SelectCommand="SELECT * FROM [Uzytkownik]" UpdateCommand=" UPDATE [Uzytkownik] SET [Nazwisko] = @Nazwisko, [Imie] = @Imie, [Kontakt] = @Kontakt, [Rola] = @Rola, [Login] = @Login, [Haslo] = @Haslo, [Uprawnienia] = @Uprawnienia WHERE [Id_Uzytkownik] = @Id_Uzytkownik">
              <DeleteParameters>
                  <asp:Parameter Name="Id_Uzytkownik" Type="Int32" />
              </DeleteParameters>
              <InsertParameters>
                  <asp:Parameter Name="Nazwisko" Type="String" />
                  <asp:Parameter Name="Imie" Type="String" />
                  <asp:Parameter Name="Kontakt" Type="String" />
                  <asp:Parameter Name="Rola" Type="String" />
                  <asp:Parameter Name="Login" Type="String" />
                  <asp:Parameter Name="Haslo" Type="String" />
                  <asp:Parameter Name="Uprawnienia" Type="Int32" />
              </InsertParameters>
              <UpdateParameters>
                  <asp:Parameter Name="Nazwisko" Type="String" />
                  <asp:Parameter Name="Imie" Type="String" />
                  <asp:Parameter Name="Kontakt" Type="String" />
                  <asp:Parameter Name="Rola" Type="String" />
                  <asp:Parameter Name="Login" Type="String" />
                  <asp:Parameter Name="Haslo" Type="String" />
                  <asp:Parameter Name="Uprawnienia" Type="Int32" />
                  <asp:Parameter Name="Id_Uzytkownik" Type="Int32" />
              </UpdateParameters>
          </asp:SqlDataSource>

        <asp:SqlDataSource ID="userDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:SRSConnectionString %>" SelectCommand="SELECT * FROM [Uzytkownik]"></asp:SqlDataSource>

    </section>
</asp:Content>
