<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Label1">
    
        <p />
        <asp:Label ID="Label2" runat="server" Text="商品编号:"></asp:Label>
        <asp:Label ID="lblSN" runat="server" Text="Label"></asp:Label>
        <p />
        <asp:Label ID="Label3" runat="server" Text="商品名称:"></asp:Label>
        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
        <p />
        <asp:Label ID="Label4" runat="server" Text="商品说明:"></asp:Label>
        <asp:Label ID="lblSCN" runat="server" Text="Label"></asp:Label>
        <p />
        <asp:Image ID="Image1" runat="server" ImageUrl="https://www.lzzy.net/upload/main/image/2018/11/12/201811121640511804_650_400.jpg" Width="400px" />
        <p />
        <asp:HyperLink ID="HyperLink1" runat="server"  NavigateUrl="~/ProductList.aspx">返回</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
