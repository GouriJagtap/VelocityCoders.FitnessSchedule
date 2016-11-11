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
        Hello World from the Instructor List page.
    </div>
</asp:Content>
