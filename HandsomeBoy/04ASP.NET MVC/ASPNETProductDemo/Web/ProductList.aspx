<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
       <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="ID" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing">
    <Columns>
        <asp:TemplateField HeaderText="编号">
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("ID", "productdetail.aspx?id={0}") %>' Text='<%# Eval("SN") %>'></asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Name" HeaderText="产品名称" />
        <asp:TemplateField HeaderText="产品类别">
           <EditItemTemplate>
                    <asp:DropDownList ID="DdlCategory" runat="server" Width="150px"></asp:DropDownList>
                </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="LblCategoty" runat="server" Text='<%# GetName(Eval("Categoty")) %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="DSCN" HeaderText="说明" />
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
    </Columns>
    </asp:GridView>
</asp:Content>

