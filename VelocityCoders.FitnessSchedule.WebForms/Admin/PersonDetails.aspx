<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonDetails.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.PersonDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <h1>Person Details</h1>
        <br/>
        <a href="Index.aspx"> Index </a>&nbsp;&nbsp;<a href="PersonList.aspx"> Person List </a>
       <br />
         
        <asp:Label runat="server" ID="lblMessage" />
        <br />
        <b>Person ID :</b> &nbsp; <asp:Label runat="server" ID="lblPersonId" />
        <br />
        <b>First Name :</b>  &nbsp; <asp:Label runat="server" ID="lblFirstName" />
        <br />
        <b>Last Name :</b>  &nbsp; <asp:Label runat="server" ID="lblLastName" />
        <br />
        <b>Preferred Name : </b>  &nbsp; <asp:Label runat="server" ID="lblDisplayFirstName" />
        <br />
        <b>Gender : </b>  &nbsp; <asp:Label runat="server" ID="lblGender" />
        </div>
        </form>
 
    
</body>
</html>
