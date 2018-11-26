<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="aspWeb.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h4>商品列表</h4>
            <asp:GridView ID="GridView1" runat="server" Font-Size="12pt" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ID" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" PageSize="18" Width="100%" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="StudentNo" HeaderText="学号" />
                    <asp:BoundField DataField="FullName" HeaderText="名字">
                    <ItemStyle Width="120px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Address" HeaderText="地址" />
                    <asp:TemplateField HeaderText="维护操作" ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="编辑"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="删除" OnClientClick=" return confirm（'你真的要删了我么？'）;"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Content>

<%--<script>
    var links = docum.links;//获取所有连接
    for (var i in links) {
        //遍历所有链接
        var a = links[i];
        if(a.text=='Delete'||a.text=='删除')
        {
            //如果是删除链接按钮
            //临时保存原来的链接
            var alink=a.alink
        }
    }
</script>--%>
