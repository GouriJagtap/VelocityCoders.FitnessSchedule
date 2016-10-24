<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorList.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.InstructorList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <h1> Instructor List </h1>
     <a href="Index.aspx"> Index </a>
     <br />
     <br />
    <table>
        <asp:Repeater ID="rptInstructorList" runat="server">
            <HeaderTemplate>
                <tr>
                    <td>InstructorId</td>
                    <td>PersonId</td>
                    <td>Hire Date</td>
                    <td>Term Date</td>
                    <td>Create Date</td>
                    <td>&nbsp;</td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("InstructorId")%></td>
                    <td><%# Eval("PersonID")%></td>
                    <td><%# Eval("HireDate")%></td>
                    <td><%# Eval("TermDate")%></td>
                    <td><%# Eval("CreateDate")%></td>
                    <td><a href='InstructorDetails.aspx?InstructorId=<%# Eval("PersonID") %>'>Details</a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    </div>
    </form>
</body>
</html>
