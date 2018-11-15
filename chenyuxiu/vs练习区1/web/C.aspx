<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="C.aspx.cs" Inherits="C" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
</asp:Content>

