<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="Lesson6.Student1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Student Details</h1>
    <h5>All fields are required</h5>

    <fieldset>
        <label for="txtLastName" class="col-sm-2">Last Name: </label>
        <asp:TextBox ID="txtLastName" runat="server" required MaxLength="50" />
    </fieldset>
    <fieldset>
        <label for="txtFirstName" class="col-sm-2">First Name: </label>
        <asp:TextBox ID="txtFirstName" runat="server" required MaxLength="50" />
    </fieldset>
    <fieldset>
        <label for="txtEnrollDate" class="col-sm-2">Enroll Date: </label>
        <asp:TextBox ID="txtEnrollDate" runat="server" required TextMode="Date" />
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Must be a Date" ControlToValidate="txtEnrollDate"
            CssClass="alert alert-danger" Type="Date" MinimumValue="01/01/2000" MaximumValue="01/01/2099"></asp:RangeValidator>
    </fieldset>

    <div>
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>
</asp:Content>
