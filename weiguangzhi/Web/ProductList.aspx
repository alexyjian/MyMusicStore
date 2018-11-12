<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="ProductList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="商品列表"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Caption="商品报表" DataKeyNames="ID" OnRowDeleting="GridView1_RowDeleting" Width="100%" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="SN" HeaderText="商品编号" />
                <asp:BoundField DataField="Name" HeaderText="商品名称" />
                <asp:BoundField DataField="DSCN" HeaderText="说明" />
                <asp:CommandField HeaderText="維護操作" ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
