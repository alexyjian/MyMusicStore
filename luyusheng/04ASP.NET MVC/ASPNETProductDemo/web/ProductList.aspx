<%@ Page Title="商品列表" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <h4>商品列表</h4>
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Caption="商品报表" DataKeyNames="ID" PageSize="18" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnRowEditing=" GridView1_RowEditing" AllowPaging="True" Height="114px" OnRowUpdating="GridView1_RowUpdating1" Width="659px">
        <Columns>
            <asp:BoundField DataField="SN" HeaderText="商品编号">
            <ItemStyle Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="商品名称">
            <ItemStyle Width="30%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="分类">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Categoty") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Categoty") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="15%" />
            </asp:TemplateField>
            <asp:BoundField DataField="DSCN" HeaderText="说明" />
            <asp:CommandField HeaderText="维护操作" ShowDeleteButton="True" ShowEditButton="True">
            <ItemStyle Width="120px" />
            </asp:CommandField>
        </Columns>
        </asp:GridView>
   
    <p style="height: 18px; width: 775px">&nbsp;</p>
</asp:Content>

