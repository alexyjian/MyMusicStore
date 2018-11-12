<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
</asp:DropDownList>
<asp:GridView  ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="ID" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
    <Columns >
        <asp:BoundField DataField="StuNo" HeaderText="学号" />
        <asp:BoundField DataField="Name" HeaderText="姓名" />
        <asp:BoundField DataField="department" HeaderText="学院" />
        <asp:BoundField DataField="Sex" HeaderText="性别" />
        <asp:BoundField DataField="Address" HeaderText="地址" />
        <asp:BoundField DataField="Phone" HeaderText="电话" />
        <asp:TemplateField HeaderText="管理" ShowHeader="False">
            <EditItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="编辑"></asp:LinkButton>
                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="删除" OnClientClick="return confirm('是否删除?');" ></asp:LinkButton>
            </ItemTemplate>
            <ItemStyle Width="70px" />
        </asp:TemplateField>
    </Columns>
    <RowStyle HorizontalAlign="Center" />
</asp:GridView>

  
</asp:Content>
