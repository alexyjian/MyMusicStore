<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Hello!!! 你好 ASP.NET!!!"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="欢迎" OnClick="Button1_Click" />
</asp:Content>
