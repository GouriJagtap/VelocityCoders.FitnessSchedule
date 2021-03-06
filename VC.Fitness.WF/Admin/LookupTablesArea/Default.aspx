﻿<%@ Page Title="LookupTable" Theme="Theme" Language="C#" MasterPageFile="~/MasterPages/Site2Column.Master" AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.LookupTablesArea.Default" %>

<%@ register    TagPrefix="CustomVelocityCoders"
                TagName="LookupTablesNavigation"
                Src="~/UserControls/LookupTablesNavigationControl.ascx" %>

<%@ Register    TagPrefix="CustomVelocityCoders"
                TagName ="MessageArea" 
                Src="~/UserControls/MessageBrokenRulesControl.ascx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CustomVelocityCoders:LookupTablesNavigation runat="server" ID="lookupTablesNavigation" />
     <CustomVelocityCoders:MessageArea runat="server" ID="customMessageArea" visible="false" />
    <div class="GenericNavigationContainer BorderRadius BorderRadiusTop">
        <span class="HeaderText">Lookup Tables</span>
    </div>
    <div id="InstructorContainer" class="BorderRadiusBottom">
        Placeholder for the Lookup Tables area.
    </div>
</asp:Content>