<%@ Control Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="LookupTablesNavigationControl.ascx.cs" 
    Inherits="VelocityCoders.FitnessSchedule.WebForms.UserControls.LookupTablesNavigationControl" %>

<div class="GenericNavigationContainer BorderRadius BorderRadiusTop">
    <span class="HeaderText">
        Manage Lookup Tables:
        &nbsp;
        <asp:DropDownList
            runat="server"
            ID="drpSelectedLookupTable"
            DataTextField="Text"
            DataValueField="Value"
            OnSelectedIndexChanged="LookupTables_Selected"
            AutoPostBack="true" />
    </span>
</div>
