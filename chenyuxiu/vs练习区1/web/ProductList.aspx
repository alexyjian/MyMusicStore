<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h4>商品列表</h4>
    <p>
        <asp:GridView ID="GridView1" runat="server" Height="138px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="773px">
            <Columns>
                <asp:BoundField DataField="SN" HeaderText="商品编号"></asp:BoundField>
                <asp:BoundField DataField="Name" HeaderText="商品名称"></asp:BoundField>
                <asp:BoundField DataField="DSCN" HeaderText="说明" />
                <asp:CommandField HeaderText="维护操作" ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
            </Columns>
        </asp:GridView>
    </p>
    <p>&nbsp;</p>
</asp:Content>

