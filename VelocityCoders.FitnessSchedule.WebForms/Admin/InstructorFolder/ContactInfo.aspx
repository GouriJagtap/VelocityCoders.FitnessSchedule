<%@ Page Title="Instructor Contact Info" 
    Theme="Theme" 
    Language="C#" 
    MasterPageFile="~/MasterPages/Site2Column.Master" 
    AutoEventWireup="true"
     CodeBehind="ContactInfo.aspx.cs" 
    Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.InstructorFolder.ContactInfo" %>

<%@ Register TagPrefix="CustomVelocityCoders" 
             TagName="InstructorNavigation" 
             Src="~/UserControls/InstructionNavigationControl.ascx" 
               %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <CustomVelocityCoders:InstructorNavigation runat="server" ID="instructorNavigation" />
    <div id="InstructorContainer" class="BorderRadiusBottom">
        Hello World from the Contact Info page.
    </div>
    </asp:Content>
