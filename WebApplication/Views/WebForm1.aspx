<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication.Views.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />

    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>




</asp:Content>
