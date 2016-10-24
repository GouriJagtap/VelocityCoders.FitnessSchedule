<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailList.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.EmailList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <h1> Email List</h1>
     <a href="Index.aspx"> Index </a>
     <br />
     <br />
    <table>
        <asp:Repeater runat="server" ID="rptEmailList">
            <HeaderTemplate>
                <tr>
                    <td>EmailId</td>
                    <td>EntityTypeID</td>
                    <td>InstructorId</td>
                    <td>EmailAddress</td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("EmailID") %></td>
                    <td><%#Eval("EntityTypeId") %></td>
                    <td><%#Eval("InstructorId") %></td>
                    <td><%#Eval("EmailAddress") %></td>
                    <td><a href="EmailDetails.aspx?EmailId=<%#Eval("EmailId")%>">Details</a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    </div>
    </form>
</body>
</html>
