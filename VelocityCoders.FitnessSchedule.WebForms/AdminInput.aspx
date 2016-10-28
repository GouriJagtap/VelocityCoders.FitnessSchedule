<%@ Page Language="C#" AutoEventWireup="true" Theme= "Main" CodeBehind="AdminInput.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.AdminInput" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Input Info</title>
   
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <style>    
    </style>
</head>
    <body>
        <div class="form">
            
           <form id="form1" runat="server" action="Thanks.aspx" method="get">   
             <div class="datagrid">
                <table id="table1">
                    <caption> Administrator Input</caption>
                    <thead>
                        <tr>
                            <th>
                                Item
                            </th>
                        <th>
                            Selection
                        </th>
                    </tr>
                </thead>
                <tbody>
                <tr id="tr1">
                    <td >First Name :</td>
                    <td> 
                        <input type="text" name="FirstName" />
                    </td>
                </tr>
                <tr id="tr2">
                    <td >Last Name :</td>
                    <td>
                        <input type="text" name="LastName" />
                    </td>
                </tr>
               
                <tr id="tr3">
                    <td>Date Of Hire </td>
                    <td>
                        <input type="date" name="DateOfHire" />
                    </td>
                </tr>
                <tr>
                    <td>Date Of Termination </td>
                    <td>
                        <input type="date" name="DateOfTermination" />
                    </td>
                </tr>
                <tr>
                    <td> Maritial Status</td>
                    <td>
                        <input type="radio" name="maritial" value="Single"> Single <br />
                        <input type="radio" name="maritial" value="Married"> Married <br />
                         <input type="radio" name="maritial" value="Divorced"> Divorced <br />
                         <input type="radio" name="maritial" value="Other"> Other <br />
                    </td>
                </tr>
                <tr>
                    <td>Pay Grade:</td>
                    <td>
                        <select name="grade">
                            <option value="admin">Admin</option>
                            <option value="admin2">Admin 2</option>
                            <option value="admin3">Admin 3</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        Comments
                    </td>
                    <td colspan="2">
                        <textarea name="Comments" rows="4" cols="25"></textarea>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        Terminate Employee <input type="checkbox" name="chkTerm" value="term" />
                    </td>
                </tr>
               <%-- <tr>
                    <td colspan="2">                         
                        <input type="submit" value="Submit Form" />
                    </td>
                </tr>--%>
                </tbody>
            </table>
         </div>
               <Center><input type="Submit" value="Submit Form" /></Center>
     </form>
</div>
    <div>
    
    </div>
</body>
</html>
