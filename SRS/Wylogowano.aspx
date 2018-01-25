<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Wylogowano.aspx.cs" Inherits="SRS.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>setTimeout(function () { location.href = 'start.aspx'; }, 1500);</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="start" runat="server">
    
    <section>
        <h2>Wylogowano pomyślnie. Zapraszamy ponowie.</h2>
    </section>
</asp:Content>
