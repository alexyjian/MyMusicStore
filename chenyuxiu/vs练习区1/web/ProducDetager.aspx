<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProducDetager.aspx.cs" Inherits="ProducDetager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        查看明细</p>
    <p>
        商品编号：<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        商品名称：<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        商品说明：<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="http://p7.qhimg.com/t01e5a2f37b3e7b12ba.jpg" OnClick="ImageButton1_Click" />
        <img alt="" longdesc ="http://localhost:65300/ProducDetager.aspx" src="file:///C:/Users/Administrator/Desktop/t01e5a2f37b3e7b12ba.jpg" style="width: 163px; height: 204px" /></p>
    <p>
        &nbsp;
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="返回" Width="93px" />
    </p>
</asp:Content>

