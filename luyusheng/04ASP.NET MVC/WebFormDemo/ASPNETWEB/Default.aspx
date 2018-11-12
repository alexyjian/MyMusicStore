<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="16px" Width="196px"></asp:DropDownList>
    <br />
  <asp:GridView ID="GridView1" runat="server" Caption="商品报表" Width="777px" AutoGenerateColumns="False" DataKeyNames="ID">
      <Columns>
          <asp:BoundField DataField="SN" HeaderText="商品编号" >
          <ItemStyle Width="120px" />
          </asp:BoundField>
          <asp:BoundField HeaderText="商品名称" DataField="Nane" >
          <ItemStyle Width="30%" />
          </asp:BoundField>
          <asp:BoundField DataField="DSCN" HeaderText="说明" >
          <ItemStyle Width="150px" />
          </asp:BoundField>
          <asp:CommandField HeaderText="维护操作" ShowDeleteButton="True" ShowEditButton="True">
          <ItemStyle Width="150px" />
          </asp:CommandField>
      </Columns>
    </asp:GridView>

</asp:Content>
