<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="departments.aspx.cs" Inherits="Lesson6.departments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Departments</h1>
    <a href="Department.aspx">Add Department</a>
    <asp:GridView ID="grdDepartments" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false" OnRowDeleting="grdDepartments_RowDeleting"
         DataKeyNames="DepartmentID">
        <Columns>
            <asp:BoundField DataField="DepartmentID" HeaderText="Department ID" />
            <asp:BoundField DataField="Name" HeaderText="Department Name" />
            <asp:BoundField DataField="Budget" HeaderText="Budget" DataFormatString="{0:C}" />
            <asp:HyperLinkField HeaderText="Edit"  Text="Edit" NavigateUrl="~/Department.aspx" DataNavigateUrlFields="DepartmentID" 
                DataNavigateUrlFormatString="Department.aspx?DepartmentID={0}" />
            <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true"/>
        </Columns>
    </asp:GridView>
</asp:Content>
