<%@ Page Title="Departments" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="departments.aspx.cs" Inherits="COMP2007_Lesson06.departments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Departments</h1>

    <a href="department.aspx">Add Department</a>
    <asp:GridView ID="grdDepartments" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false" OnRowDeleting="grdDepartments_RowDeleting" DataKeyNames="DepartmentID">
        <Columns>
            <asp:BoundField DataField="DepartmentID" HeaderText="Department ID" SortExpression="DepartmentID" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Budget" HeaderText="Budget" DataFormatString="{0:C2}" SortExpression="Budget" />
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/department.aspx" DataNavigateUrlFields="DepartmentID" DataNavigateUrlFormatString="department.aspx?DepartmentID={0}" />
            <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</asp:Content>