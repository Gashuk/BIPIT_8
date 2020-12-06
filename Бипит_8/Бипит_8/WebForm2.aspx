<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Бипит_8.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Оборудование:&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" Width="245px">
        </asp:DropDownList>
</p>
    <p>
        Вид работ:
        <asp:DropDownList ID="DropDownList2" runat="server" Width="233px">
        </asp:DropDownList>
</p>
    <p>
        Дата получение:&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Width="209px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Неверный формат даты" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"></asp:RegularExpressionValidator>
</p>
    <p>
        Дата сдачи:&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Width="209px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox1" ErrorMessage="Неверный формат даты" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"></asp:RegularExpressionValidator>
    <br />
</p>
<p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Добавить" Width="175px" />
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
</asp:Content>
