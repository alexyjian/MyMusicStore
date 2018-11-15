<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <h4>商品明细</h4>
        <asp:Label ID="Label1" runat="server" Text="商品编号："></asp:Label>
        <asp:Label ID="lblSN" runat="server" Text="Label"></asp:Label>
    
    </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="商品名称："></asp:Label>
            <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="商品说明："></asp:Label>
            <asp:Label ID="lblDSCN" runat="server" Text="Label"></asp:Label>
        </p>
    </form>
</body>
</html>
