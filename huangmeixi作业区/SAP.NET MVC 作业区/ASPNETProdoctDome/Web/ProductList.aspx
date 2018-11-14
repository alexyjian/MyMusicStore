﻿<%@ Page Title="商品列表" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h4>商品列表</h4>
         <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" Caption="商品报表" DataKeyNames="ID" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" PageSize="18" Width="100%" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
        <Columns>
            <asp:BoundField DataField="SN" HeaderText="商品编号" >
            <FooterStyle Width="200%" />
            </asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="商品名称">
            <FooterStyle Width="30%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="分类">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Categoty") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LblCategory" runat="server" BackColor="#9999FF" Text='<%# GatName(Eval("Categoty")) %>'></asp:Label>
                </ItemTemplate>
                <FooterStyle Width="15%" />
            </asp:TemplateField>
            <asp:BoundField DataField="DSCN" HeaderText="说明">
            <FooterStyle Width="200%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="维护操作" ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="编辑"></asp:LinkButton>
                   &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="删除" OnClientClick="return confirm('你真的要删了我么？');"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
 
</asp:Content>

