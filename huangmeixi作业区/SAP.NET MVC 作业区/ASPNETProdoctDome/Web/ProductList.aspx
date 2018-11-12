<%@ Page Title="商品列表" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h4>商品列表<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" Caption="商品列表" DataKeyNames="ID" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" Width="100%">
        <Columns>
            <asp:BoundField DataField="SN" HeaderText="商品编号" />
            <asp:BoundField DataField="Name" HeaderText="商品名称">
            <FooterStyle Width="30%" />
            </asp:BoundField>
            <asp:BoundField DataField="DSCN" HeaderText="说明">
            <FooterStyle Width="200%" />
            </asp:BoundField>
            <asp:CommandField HeaderText="维护操作" ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
        </asp:GridView>
    </h4>


</asp:Content>

