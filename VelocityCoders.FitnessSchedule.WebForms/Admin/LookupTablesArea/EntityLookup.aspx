<%@ Page Title="EntityLookup" Theme="Theme" Language="C#" MasterPageFile="~/MasterPages/Site2Column.Master" AutoEventWireup="true"
     CodeBehind="EntityLookup.aspx.cs" 
    Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.LookupTablesArea.EntityLookup" %>

<%@ Register TagPrefix="CustomVelocityCoders"
             TagName="LookupTablesNavigation" 
             Src="~/UserControls/LookupTablesNavigationControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CustomVelocityCoders:LookupTablesNavigation runat="server" Id="lookupTablesNavigation" />
    <div id="InstructorContainer" class="BorderRadiusBottom">
        <div class="SectionMessageArea SmallText"><label class="Required">*</label>=Required Field</div>
        Hello Programming!
    </div>
</asp:Content>
