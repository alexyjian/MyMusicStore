<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
        <h4>查看明细</h4>
    <p>
        商品编号:<asp:Label ID="SN" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        商品名称:<asp:Label ID="Name" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        商品说明:<asp:Label ID="DSCN" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ProductList.aspx">返回</asp:HyperLink>
    </p>
</asp:Content>

