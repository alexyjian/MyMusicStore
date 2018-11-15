<%@ Page Title="商品列表" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h4>商品列表</h4>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" Caption="商品报表" DataKeyNames="ID" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" PageSize="18" Width="100%">
        <Columns>
            <asp:BoundField DataField="SN" HeaderText="商品编号" />
            <asp:BoundField DataField="Name" HeaderText="商品名称" />
            <asp:BoundField DataField="DSCN" HeaderText="说明" />
            <asp:CommandField HeaderText="维护操作" ShowDeleteButton="True" ShowEditButton="True">
            <HeaderStyle Width="150px" />
            <ItemStyle Width="150px" />
            </asp:CommandField>
        </Columns>
    </asp:GridView>

    <script>
        var links = document.links;//获取所有连接
        for (var i in links) {
            //遍历所有连接
            var a = links[i];
            if (a.text == 'Delete' || a.text == '删除') {
                //如果是删除连接按钮
                //临时保存原来的连接
                var alink = a.href;
                //清除原连接，为了确认是否继续
                a.href = "#";
                //添加JS事件，加确认弹窗
                a.addEventListener("click", function () {
                    var result = window.confirm('你是认真的吗？该记录会被删除！');
                    if (result == true)
                        //如果用户确认,执行原来的链接
                        eval(alink);
                    return false;
                });
            }
        }
</script>

</asp:Content>


