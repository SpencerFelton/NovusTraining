<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="WingtipToys.Feedback" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Feedback Form</h3>
    <p>Please fill in the details below to give us feedback about your experience.</p>
    <asp:Label ID="emailAddressLabel" runat="server" Text="Email Address"></asp:Label>   <asp:TextBox ID="emailAddress" placeholder="Someone1234@gmail.com" runat="server"></asp:TextBox>
    <br /><br /><br />
    <asp:DropDownList ID="categoryDropdown" OnSelectedIndexChanged="categoryDropdown_SelectedIndexChanged" AutoPostback="true" runat="server"></asp:DropDownList>
    <asp:DropDownList ID="productDropdown" AutoPostback="true" runat="server"></asp:DropDownList>
    <br /><br />
    <asp:TextBox ID="feedbackTextBox" placeholder="Please type your feedback here!" TextMode="MultiLine" Rows=10 runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="feedbackSubmit" runat="server" OnClick="feedbackSubmit_Click" AutoPostBack="true" Text="Submit"/>
</asp:Content>