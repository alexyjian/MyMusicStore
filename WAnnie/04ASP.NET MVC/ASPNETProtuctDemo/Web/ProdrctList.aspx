<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProdrctList.aspx.cs" Inherits="ProdrctList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h4>商品列表<asp:GridView ID="GridView1" runat="server" Height="80px" Width="100%" AllowPaging="True" AutoGenerateColumns="False" Caption="商品报表" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="ID" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
        <Columns>
            <asp:BoundField DataField="SN" HeaderText="商品编号" >
            <ItemStyle Width="130px" />
            </asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="商品名称" >
            <ItemStyle Width="30%" />
            </asp:BoundField>
            <asp:BoundField DataField="DSCN" HeaderText="说明" />
            <asp:TemplateField HeaderText="维护操作" ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="编辑"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="删除" OnClientClick="return confirm('你真的要删除我么?');"></asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle Width="150px" />
                <ItemStyle Width="150px" />
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
    </h4>
</asp:Content>

