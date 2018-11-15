<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="A.aspx.cs" Inherits="A" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

  
    <p>
         <h4>页面的状态管理</h4>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br/>
        <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
    </p>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <br/>
</asp:Content>

