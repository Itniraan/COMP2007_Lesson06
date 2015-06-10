<%@ Page Title="Add/Edit Departments" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="department.aspx.cs" Inherits="COMP2007_Lesson06.department" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Department Details</h1>
    <h5>All fields are required</h5>

    <fieldset>
        <label for="txtName" class="col-sm-2">Name: </label>
        <asp:TextBox ID="txtName" runat="server" required="true" MaxLength="50" />
    </fieldset>
    <fieldset>
        <label for="txtBudget" class="col-sm-2">Budget: </label>
        <asp:TextBox ID="txtBudget" runat="server" required="true" MaxLength="50" />
    </fieldset>

    <div class="col-sm-offset-2">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>
</asp:Content>
