<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GymTest.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.GymLocationArea.GymTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
<div>
<table>
        <asp:Repeater runat="server" ID="rptEmailList">
            <HeaderTemplate>
                <tr>
                    <td>GymId</td>
                    <td>GymName</td>
                    <td>Abbreviation</td>
                    <td>Website</td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("GymId") %></td>
                    <td><%#Eval("GymName") %></td>
                    <td><%#Eval("Abbreviation") %></td>
                    <td><%#Eval("Website") %></td>
                    <%--<td><a href="EmailDetails.aspx?EmailId=<%#Eval("EmailId")%>">Details</a></td>--%>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    </div>
    </form>
</body>
</html>
