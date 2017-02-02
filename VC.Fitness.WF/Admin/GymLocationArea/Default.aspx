<%@ Page Title="GymLocation"Theme="Theme" Language="C#" MasterPageFile="~/MasterPages/Site2Column.Master" AutoEventWireup="true"
     CodeBehind="Default.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.GymLocationArea.Default" %>


<%@ Register    TagPrefix="CustomVelocityCoders" 
                TagName="GymLocationNavigation"
                Src="~/UserControls/GymLocationNavigationControl.ascx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CustomVelocityCoders:GymLocationNavigation runat="server" ID="gymLocationNavigation" />
    <div class="GenericNavigationContainer BorderRadius BorderRadiusTop">
        <span class="HeaderText">Gym Location</span>
    </div>
    <div id="InstructorContainer" class="BorderRadiusBottom">
        Placeholder for the Gym Location area.
    </div>
</asp:Content>
