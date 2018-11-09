<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


 
        <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="Page_Load">
        </asp:DropDownList>
    
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>

</asp:Content>
