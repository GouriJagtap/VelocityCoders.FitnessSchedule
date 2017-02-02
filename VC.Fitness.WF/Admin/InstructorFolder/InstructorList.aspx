<%@ Page Title="Instructor List" 
    Language="C#" 
    MasterPageFile="~/MasterPages/Site2Column.Master" 
    AutoEventWireup="true"
     CodeBehind="InstructorList.aspx.cs" 
    Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.InstructorFolder.InstructorList" 
    Theme="Theme" %>

<%@ Register TagPrefix="CustomVelocityCoders" 
             TagName="InstructorNavigation" 
             Src="~/UserControls/InstructionNavigationControl.ascx"
              %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <CustomVelocityCoders:InstructorNavigation runat="server" ID="instructorNavigation" />
    <div id="InstructorContainer" class="BorderRadiusBottom">
        <table>
            <asp:Repeater runat="server" Id="rptInstructorList">
                <HeaderTemplate>
                    <tr>
                        <td>First Name</td>
                        <td>Last Name</td>
                        <td>Display Name</td>
                        <td>Gender</td>
                        <td>Hire Date</td>
                        <td>Term Date</td>
                        <td>Employee Type</td>
                        <td>&nbsp</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("FirstName") %></td>
                        <td><%# Eval("LastName") %></td>
                        <td><%# Eval("DisplayFirstName") %></td>
                        <td class="TextCenter"><%# Eval("Gender") %></td>
                         <td class="TextCenter"><%# Eval("HireDate") %></td>
                         <td class="TextCenter"><%# Eval("TermDate") %></td>
                         <td class="TextCenter"><%# Eval("EntityTypeId") %></td>
                        <td class="TextCenter"><a href='InstructorForm.aspx?InstructorId=<%# Eval("InstructorId") %>'>Edit</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>
 