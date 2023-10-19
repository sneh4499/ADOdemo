<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CascadingDropdown.aspx.cs" Inherits="ADOdemo.CascadingDropdown" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center><h1>Cascading Dropdown Example</h1></center>
            <asp:DropDownList ID="DropDownList1" CssClass="form-control" AutoPostBack="true" runat="server" DataSourceID="SqlDataSource1" DataTextField="State" DataValueField="State" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem value="">Please Select</asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ADOtableConnectionString %>" ProviderName="<%$ ConnectionStrings:ADOtableConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT [State] FROM [Cities]"></asp:SqlDataSource>
            
            
            <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server">
                <asp:ListItem value="">Please Select</asp:ListItem>
            </asp:DropDownList>

        </div>
    </form>
</body>
</html>
