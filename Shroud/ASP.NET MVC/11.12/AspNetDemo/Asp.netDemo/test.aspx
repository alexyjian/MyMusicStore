<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <h3>this is test</h3>
    <asp:GridView ID="GridView1" runat="server" Caption="学生列表" Width="100%" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" AllowPaging="True" DataKeyNames="ID" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowEditing="GridView1_RowEditing" PageSize="5" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating">
        <Columns>
            <asp:TemplateField HeaderText="姓名">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("ID", "StuD?Id={0}") %>' Text='<%# Eval("Name") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Sex" HeaderText="性别" />
            <asp:BoundField DataField="Age" HeaderText="年龄" />
            <asp:TemplateField HeaderText="学院">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="71px" DataSource="<%# GetDepartMent() %>" DataTextField='<%# "Name" %>' DataValueField='<%# "ID" %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# GetName(Eval("DepartMent")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" HeaderText="操作">
                <ControlStyle Width="30px" />
            </asp:CommandField>
            <asp:BoundField DataField="DepartMent" Visible="False" />
        </Columns>

    </asp:GridView>
    <%--<script>
        var a = document.getElementsByTagName('a');
        var alinks=[];
        for (var l = 0; l < a.length;l++)
        {
            if (a[l].text == "删除") {
                alinks.push(a[l]);
                console.log(a[l]);
            }
        }
        var lk
        for (var i = 0; i < alinks.length; i++)
        {
            i.index=i;
            alinks[i].href = function () {
                lk=alinks[i.index].href;
                var b = confirm("确认删除?");
                if (!b) return "#";
                else return lk;

            }
        }
    </script>--%>


</asp:Content>

