<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HTMLIntro.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.HTMLIntro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ToDo: Add Title Here</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <a href="HelloWorld.aspx">
                <img src="Images/Agates.jpg" alt="Background Image" />
                 </a>
            </center>
            <a href="HelloWorld.aspx"> Another Hello World Page</a>
            <br />
            <a href="mailto:dan@velocitycoders.com">Email DAn</a>
        </div>
    <div>
        Some Content here...
        
        <b>Bold</b>
        <i>Italic</i>
        <u>Underline</u>
        <h1>Heading1</h1>
        <h2>Heading2</h2>
        <h3>Heading3</h3>
        <center>In the Middle</center>
        <ol type='A' starts='5'>
            <li>First</li>
            <li>Second</li>
        </ol>
        <ul type="circle">
            <li> First</li>
            <li> Second</li>
          
        </ul>
    </div>
        <div>
            <h2>Page Navigation</h2>
            <h1>Hello Web</h1>
            <p>The <b>Hello Web</b> page is a <i><u> page to learn HTML </u></i></p>
            <h3> More Page Conttent </h3>
            <table border="1">
                <tr>
                    <th> Column 1</th>
                    <th> Column 2</th>
                    <th> Column 3</th>
                    <th> Column 4</th>
                </tr>
                <tr>
                    <td> Data 1</td>
                    <td> Data 2</td>
                    <td colspan="2">Data 3</td>
                </tr>
            </table>
            <br />
            <br />
            <h2> iFrame Example </h2>
            <iframe src="HelloWorld1.aspx"></iframe>
        </div>
    </form>
</body>
</html>
