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
    
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="ID" Height="67px" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" Width="100%">
            <Columns>
                <asp:BoundField DataField="SN" HeaderText="商品编号" />
                <asp:BoundField DataField="Name" HeaderText="商品名称" />
                <asp:BoundField DataField="DSCN" HeaderText="说明" />
                <asp:CommandField HeaderText="维护操作" ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
