<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Web.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4>商品列表</h4>
    <h4>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Caption="商品报表" DataKeyNames="ID" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" PageSize="18" Width="106%" AllowPaging="True" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="商品编号">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSN" runat="server" Height="27px" Text='<%# Eval("SN") %>' Width="158px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("ID", "ProductDetail.aspx？id={0}") %>' Text='<%# Eval("SN", "{0}") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="商品名称" />
                <asp:TemplateField HeaderText="分类">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DdlCategory" runat="server" Height="25px" Width="120px">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LblCategory" runat="server" ForeColor="#669999" Text='<%# GetName(Eval("Category")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DSCN" HeaderText="商品说明">
                <ItemStyle Width="300px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="维护操作" ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="编辑"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="删除"  OnClientClick="return confirm('你真的要如此狠心。。。删了我么？');" ></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="150px" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </h4>
</asp:Content>
