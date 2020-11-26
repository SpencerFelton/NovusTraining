<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAdo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DropDownList ID="DropDownList2" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostback="true" runat="server"></asp:DropDownList>
        <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" server="" Text="Read" Visible="False" />
        <asp:DropDownList ID="DropDownList1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostback="true" runat="server" Visible="False"></asp:DropDownList>
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" AutoPostBack="true" Text="Create" Visible="False"/>
        <asp:TextBox ID="customerID" placeholder="CustomerID" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="companyName" placeholder="CompanyName" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="contactName" placeholder="ContactName" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="contactTitle" placeholder="ContactTitle" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="address" placeholder="Address" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="city" placeholder="City" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="region" placeholder="Region" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="postCode" placeholder="PostalCode" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="country" placeholder="Country" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="phone" placeholder="Phone" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="fax" placeholder="Fax" runat="server" Visible="False"></asp:TextBox>
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" AutoPostBack="true" Text="Update" Visible="False"/>
        <asp:TextBox ID="customerIDUpdate" placeholder="CustomerID" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="companyNameUpdate" placeholder="CompanyName" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="contactNameUpdate" placeholder="ContactName" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="contactTitleUpdate" placeholder="ContactTitle" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="addressUpdate" placeholder="Address" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="cityUpdate" placeholder="City" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="regionUpdate" placeholder="Region" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="postCodeUpdate" placeholder="PostalCode" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="countryUpdate" placeholder="Country" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="phoneUpdate" placeholder="Phone" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="faxUpdate" placeholder="Fax" runat="server" Visible="False"></asp:TextBox>
        <br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" AutoPostBack="true" Text="Delete" Visible="False"/>
        <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>

