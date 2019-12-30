<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_11_9ASP.net._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   

    <asp:DropDownList ID="DropDownList1" runat="server" Height="31px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="189px" AutoPostBack="True">
</asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 

   <asp:GridView ID="GridView1" runat="server"></asp:GridView>

</asp:Content>
