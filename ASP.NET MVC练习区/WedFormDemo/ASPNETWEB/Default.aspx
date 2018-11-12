<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>

    <br />

    <asp:GridView ID="GridView1" runat="server" Height="225px" Width="300px"></asp:GridView>
</asp:Content>
