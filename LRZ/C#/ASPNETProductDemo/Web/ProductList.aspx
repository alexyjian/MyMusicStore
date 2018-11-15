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

</asp:Content>

