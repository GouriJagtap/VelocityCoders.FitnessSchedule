<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="D-04-Instance-vs-Static-LAB.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.D_04_Instance_vs_Static_LAB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     Input 1 if you want to convert from Celsius to Fahrenheit
     And 2 if you want to convert Fahreinheit to Celsius           :&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:TextBox runat ="server" Id="TextBox1"/>
        <br />              
        <br />

        <asp:button runat="server" text="Submit" />
        <br />
        <br />

        Input the temperature you want to convert <asp:TextBox runat ="server" Id="TextBox2"/>
        <br />              
        <br />
        
        <asp:button runat="server" text="Submit" />
        <br />
        <br />

        <asp:Label ID="lblDisplayMessage1" runat="server">
        </asp:Label>
    </div>
    </form>
</body>
</html>
