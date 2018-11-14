<%@ Page Title="商品列表" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h4>商品列表</h4>
    <asp:GridView ID="GridView1" runat="server" Caption="商品报表" Width="100%"></asp:GridView>
</asp:Content>

