<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorDetails.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.InstructorDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <h1>Instructor Details</h1>
        <br/>
        <a href="Index.aspx"> Index </a>&nbsp;&nbsp;<a href="InstructorList.aspx"> Instructor List </a>
       <br />
         
        <asp:Label runat="server" ID="lblMessage" />
        <br />
        <b>Instructor ID :</b> &nbsp; <asp:Label runat="server" ID="lblInstructorId" />
        <br />
        <b>Person Id  :</b>  &nbsp; <asp:Label runat="server" ID="lblPersonId" />
        <br />
        <b>EntityType Id  :</b>  &nbsp; <asp:Label runat="server" ID="lblEntityTypeId" />
        <br />
        <b>Hire Date :</b>  &nbsp; <asp:Label runat="server" ID="lblHireDate" />
        <br />
        <b>Term Date :</b>  &nbsp; <asp:Label runat="server" ID="lblTermDate" />
        <br />
        <b> Create Date : </b>  &nbsp; <asp:Label runat="server" ID="lblCreateDate" />
        <br />
       
    </div>
    </form>
</body>
</html>
