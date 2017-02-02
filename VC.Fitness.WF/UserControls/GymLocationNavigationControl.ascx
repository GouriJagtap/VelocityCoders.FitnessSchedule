<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GymLocationNavigationControl.ascx.cs" 
    Inherits="VelocityCoders.FitnessSchedule.WebForms.UserControls.GymLocationNavigationControl" %>

<div class="GenericNavigationContainer BorderRadius BorderRadiusTop">
    <span class ="HeaderText">
        Manage:
        &nbsp;
        <asp:DropDownList
            runat="server"
            ID="drpSelectionGymLocation"
            DataTextField="Text"
            DataValueField="Value"
            OnSelectedIndexChanged="GymLocation_Selected"
            AutoPostBack="true" />
    </span>
</div>