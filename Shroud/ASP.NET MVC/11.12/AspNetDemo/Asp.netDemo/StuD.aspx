<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="StuD.aspx.cs" Inherits="StuD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    姓名:<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
    学号:<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
    年龄:<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br />
    性别:<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label><br />
    学院:<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label><br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="test.aspx">返回</asp:HyperLink>
</asp:Content>

