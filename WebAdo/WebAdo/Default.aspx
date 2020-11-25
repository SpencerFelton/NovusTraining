<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAdo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" server="" Text="Read" />
        <asp:DropDownList ID="DropDownList1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostback="true" runat="server"></asp:DropDownList>
        <br />
        <asp:Button ID="Button2" runat="server" AutoPostback="true" Text="Create" />
        <asp:TextBox ID="customerID" placeholder="CustomerID" runat="server"></asp:TextBox>
        <asp:TextBox ID="companyName" placeholder="CompanyName" runat="server"></asp:TextBox>
        <asp:TextBox ID="contactName" placeholder="ContactName" runat="server"></asp:TextBox>
        <asp:TextBox ID="contactTitle" placeholder="ContactTitle" runat="server"></asp:TextBox>
        <asp:TextBox ID="address" placeholder="Address" runat="server"></asp:TextBox>
        <asp:TextBox ID="city" placeholder="City" runat="server"></asp:TextBox>
        <asp:TextBox ID="region" placeholder="Region" runat="server"></asp:TextBox>
        <asp:TextBox ID="postCode" placeholder="PostalCode" runat="server"></asp:TextBox>
        <asp:TextBox ID="country" placeholder="Country" runat="server"></asp:TextBox>
        <asp:TextBox ID="phone" placeholder="Phone" runat="server"></asp:TextBox>
        <asp:TextBox ID="fax" placeholder="Fax" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button3" runat="server" Text="Update" />
        <br />
        <asp:Button ID="Button4" runat="server" Text="Delete" />
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>

