<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="aspWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>&nbsp;</h1>
        <p>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="34px" Width="226px">
            </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查询" />
        </p>
        <p class="lead">
            <asp:GridView ID="GridView1" runat="server" Font-Size="12pt">
            </asp:GridView>
        </p>
    </div>

    <div class="row">
    </div>

</asp:Content>
