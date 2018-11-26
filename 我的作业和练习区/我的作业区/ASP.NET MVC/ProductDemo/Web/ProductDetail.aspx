<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>查询明细</h3>
    <p>
        <asp:Label ID="Label1" runat="server" Text="商品编号："></asp:Label>
        <asp:Label ID="LblSN" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="商品名称："></asp:Label>
        <asp:Label ID="LblName" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="商品说明："></asp:Label>
        <asp:Label ID="LblDSCN" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Image ID="Image1" runat="server" />
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="返回" OnClick="Button1_Click" />
    </p>
</asp:Content>

