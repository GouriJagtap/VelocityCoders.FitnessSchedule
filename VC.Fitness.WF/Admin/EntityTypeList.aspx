<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntityTypeList.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.EntityTypeList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1> Entity Type List</h1>
     <a href="Index.aspx"> Index </a>
     <br />
     <br />
    <table>
        <asp:Repeater runat="server" ID="rptEntityTypeList">
            <HeaderTemplate>
                <tr>
               
                    <td>EntityTypeID</td>
                    <td>EntityId</td>
                    <td>EntityTypeName</td>
                    
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    
                    <td><%#Eval("EntityTypeId") %></td>
                    <td><%#Eval("EntityId") %></td>
                    <td><%#Eval("EntityTypeName") %></td>
                    <td><a href="EntityTypeDetails.aspx?EntityTypeId=<%#Eval("EntityTypeId")%>">Details</a></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    </div>
    </form>
</body>
</html>
