<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>查看明细</h3>
    <p>
        商品编号：<asp:Label ID="LblSN" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        商品名称：<asp:Label ID="LblName" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        商品说明：<asp:Label ID="LblDSCN" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Image ID="Image1" runat="server" Height="168px" ImageUrl="http://img2.imgtn.bdimg.com/it/u=1849534608,1766635208&amp;fm=15&amp;gp=0.jpg" Width="313px" />
    </p>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server">返回</asp:HyperLink>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>

