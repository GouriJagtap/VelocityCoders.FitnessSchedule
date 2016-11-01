<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonList.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.PersonList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
 <form id="form1" runat="server">
 <div>
     <h1> Person List </h1>
     <a href="Index.aspx"> Index </a>
     <br />
     <br />

  <table>
        <asp:Repeater ID="rptPersonList" runat="server">
            <HeaderTemplate>
                <tr>
                    <td>PersonId</td>
                    <td>FirstName</td>
                    <td>LastName</td>
                    <td>DisplayFirstName</td>
                    <td>Gender</td>
                    <td>BirthDate</td>
                    <td>&nbsp;</td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("PersonID")%></td>
                    <td><%# Eval("FirstName")%></td>
                    <td><%# Eval("LastName")%></td>
                    <td><%# Eval("DisplayFirstName")%></td>
                    <td><%# Eval("Gender")%></td>
                     <td><%# Eval("BirthDate")%></td>
                    <td><a href='PersonDetails.aspx?PersonId=<%# Eval("PersonID") %>'>Details</a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    </div>
    </form>
</body>
</html>
