<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="Web.ProductDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 


    <p>
        商品编号：<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        商品名称：<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        商品说明：<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <img src="A.aspx" /></p>
    <p><br />
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="bg-primary" NavigateUrl="~/ProductList.aspx" Height="24px" Width="43px">返回</asp:HyperLink>
    </p>

 


</asp:Content>
