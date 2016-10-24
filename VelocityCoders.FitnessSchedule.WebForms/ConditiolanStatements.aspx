<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConditiolanStatements.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.ConditiolanStatements" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:label id="lblOutputMessage" runat="server" />
        <br />
    <asp:label id="lblOutputMessage1" runat="server" />
        <br />
    <asp:label id="lblOutputMessage2" runat="server" />
        <br />
    <asp:label id="lblOutputMessage3" runat="server" />
        <br />
    <asp:label id="lblOutputMessage4" runat="server" />
        <br />
    <asp:label id="lblOutputMessage5" runat="server" />
        <br />
    <asp:label id="lblDisplayMessage6" runat="server" />
        <br />
        <br />
    Car Make: &nbsp;&nbsp; <asp:TextBox runat ="server" ID ="txtCarMake" />
        <br />
        (Honda, Ford, Chevy, etc)
        <br />
        <br />
    <asp:button runat="server" Text="Submit" />
        <br />

   
    </div>
    </form>
</body>
</html>
