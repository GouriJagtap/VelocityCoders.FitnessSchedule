<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailDetails.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.EmailDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1> Email Address Details </h1>
        <br />
         <br/>
        <a href="Index.aspx"> Index </a>&nbsp;&nbsp;<a href="EmailList.aspx"> Person List </a>
       <br />
        <asp:Label runat="server" ID="lblMessage" />
        <br />
        <b> Email Id </b> &nbsp; <asp:Label runat="server" ID="lblEmailId" />
        <br />
        <b> Entity Type Id </b> &nbsp; <asp:Label runat="server" ID="lblEntityTypeId" />
        <br />
        <b> Instructor Id </b> &nbsp; <asp:Label runat="server" ID="lblInstructorId" />
        <br />
        <b> Email Address </b> &nbsp; <asp:Label runat="server" ID="lblEmailAddress" />
    </div>
    </form>
</body>
</html>
