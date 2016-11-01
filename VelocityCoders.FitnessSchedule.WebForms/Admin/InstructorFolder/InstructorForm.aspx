<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorForm.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.InstructorFolder.InstructorForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
    <div>
    <img src="/Images/header-logo.png" />
        <br />
        <br />
        Current Time Is : <asp:Label runat="server" ID="lblPageMessage" />
        <br />
        <br />

        <table>
            <tr>
                <td><label>First Name</label></td>
                <td><asp:TextBox runat="server" ID="txtFirstName" MaxLength="50" /> </td>
            </tr>
            <tr>
                <td><label>Prefered First Name</label></td>
                <td><asp:TextBox runat="server" ID="txtPreferedFirstName" MaxLength="50" /> </td>
            </tr>
          
             <tr>
                <td><label>Last Name</label></td>
                <td><asp:TextBox runat="server" ID="txtLastName" MaxLength="50" /> </td>
            </tr>
             <tr>
                <td><label> Date Of Birth </label></td>
                <td><asp:TextBox runat="server" ID="txtBirthDate" MaxLength="10" /> </td>
            </tr>
            <td colspan="2"><hr /></td>
            <tr>
                <td><label> Date Of Hire </label></td>
                <td><asp:TextBox runat="server" ID="txtHireDate" MaxLength="10" /> </td>
            </tr>
            <tr>
                <td><label> Date Of Termination </label></td>
                <td><asp:TextBox runat="server" ID="txtTermDate" MaxLength="10" /> </td>
            </tr>
            <tr>
                <td><label> Employee Type </label></td>
                <td>
                    <asp:DropDownList runat="server" ID="drpEmployeeType">
                        <asp:ListItem Text="(Select Employee Type)" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td><label> Gender </label></td>
                <td>
                    <asp:DropDownList runat="server" ID="drpGender">
                        <asp:ListItem Text="(Select Gender)" Value="0" />
                        <asp:ListItem Text="Male" Value="Male" />
                        <asp:ListItem Text="Female" Value="Female" />
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td><label>Notes : </label></td>
                <td><asp:TextBox runat="server" ID="txtNotes" TextMode="MultiLine" /> </td>
            </tr>
        </table>
        <br />
        <asp:Button runat="server" Text="Save" />
    </div>
    </form>
</body>
</html>
