<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntityTypeDetails.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.EntityTypeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1> Entity Type Details </h1>
        <br />
         <br/>
        <a href="Index.aspx"> Index </a>&nbsp;&nbsp;<a href="EntityTypeList.aspx"> Entity Type List </a>
       <br />
        <asp:Label runat="server" ID="lblMessage" />
        <br />
        <b> Entity Type Id </b> &nbsp; <asp:Label runat="server" ID="lblEntityTypeId" />
        <br />
        <b> Entity Id </b> &nbsp; <asp:Label runat="server" ID="lblEntityId" />
        <br />
        <b>Entity Type Name </b> &nbsp; <asp:Label runat="server" ID="lblEntityTypeName" />
        <br />
       
    </div>
    </form>
</body>
</html>
