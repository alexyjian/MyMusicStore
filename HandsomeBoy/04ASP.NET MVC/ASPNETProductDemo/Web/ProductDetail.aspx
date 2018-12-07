<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>商品明细</h3>
    <asp:Label ID="Label1" runat="server" Text="商品名称："></asp:Label>
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="商品编号："></asp:Label>
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="Label5" runat="server" Text="商品说明："></asp:Label>
    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:LinkButton ID="LinkButton1"  runat="server" CssClass="btn btn-primary" OnClick="LinkButton1_Click">返回</asp:LinkButton>

</asp:Content>

