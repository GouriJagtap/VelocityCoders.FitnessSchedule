<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FitnessCLassDetails.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.FitnessCLassDetails" %>

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
        <a href="Index.aspx"> Index </a>&nbsp;&nbsp;<a href="FitnessClassList.aspx"> Fitness Class List </a>
       <br />
         
        <asp:Label runat="server" ID="lblMessage" />
        <br />
        <b>Fitness Class ID :</b> &nbsp; <asp:Label runat="server" ID="lblFitnessClassId" />
        <br />
        <b>Fitness Class Name  :</b>  &nbsp; <asp:Label runat="server" ID="lblFitnessClassName" />
       
       
    </div>
    </form>
</body>
</html>
