<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductDetali.aspx.cs" Inherits="ProductDetali" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h4>查看明细</h4>
        <br />
        <asp:Label ID="Label5" runat="server" Text="商品说明："></asp:Label>
        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
        <br />
    
        <asp:Label ID="Label1" runat="server" Text="商品名称："></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="商品说明："></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Image ID="Image1" runat="server" Width="200px" ImageUrl="" />
    
        <br />
         <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-primary" NavigateUrl="~/ProductList.aspx">返回</asp:HyperLink>
    
    </div>
    </form>
</body>
</html>
