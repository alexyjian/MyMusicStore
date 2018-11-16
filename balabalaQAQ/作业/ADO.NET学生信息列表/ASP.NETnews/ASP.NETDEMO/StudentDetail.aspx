<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentDetail.aspx.cs" Inherits="StudentDetail" %>

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
    </div>
        <asp:Label runat="server" Text="学生学号："></asp:Label>
        <asp:Label ID="StuID" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label runat="server" Text="学生姓名："></asp:Label>
        <asp:Label ID="StuName" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label runat="server" Text="电话："></asp:Label>
        <asp:Label ID="Stuphone" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="返回" />
    </form>
</body>
</html>
