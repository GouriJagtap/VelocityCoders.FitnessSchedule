<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Thanks.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.Thanks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thank You</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <script type="text/javascript">
        function getValue(varname)
        {
            //First, we load the URL into a variable
            var url = window.location.href;
            //Next, we split the URL by the ?
            var uparts = url.split("?");
            //Check that there is a querystring, return "" if not
            if(uparts.length==0)
            {
                return "";
            }
            //Then find the querystring, everything after the ?
            var query = uparts[1];
            //Split the query string into variables(seperated by &
            var vars = query.split("&");
            //Iterate through vars, checking each one for varname
            for(i = 0;i<vars.length;i++)
            {
                //Split the variables by =, which splits name and value
                var parts = vars[i].split("=");
                //Check for the correct variable 
                if(parts[0]==varname)
                {
                    //Load value into variable
                    value = parts[1]
                    break;
                }
            }
                    value = unescape(value);
                    //Convert "+"s to ""s
                    value.replace(/\+/g, " ");
                    //return value
                    return value;
   }
            
        
    </script></head>
<body>
    <form id="form1" runat="server">
    <div>
    Thank you for clicking on the Submit button.
        <table>
            <tr>
                <td>
                    You Entered the First Name:
                </td>
            <td>
                <script type="text/javascript">
                    var Fname = getValue("FirstName");
                    document.write(Fname);
                </script>
            </td>
            <td>
                <script type="text/javascript">
                    var Lname = getValue("LastName");
                    document.write(Lname);
                </script>
            </td>

            </tr>

        </table>
    </div>
    </form>
</body>
</html>
