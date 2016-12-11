<%@ Page Title="Error" Theme="Theme" Language="C#" MasterPageFile="~/MasterPages/Site2Column.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="GenericNavigationContainer BorderRadius BorderRadiusTop">
        <span class="HeaderText">Page Error</span>
    </div>
    <div id="GenericContainer">
        <div class="HeaderText">Error Occured</div>
        <p>
            Ann error occured while processoing your request.
            Your request and error information has been logged and the web team has been notified.
            Please click <asp:HyperLink runat="server" ID="PreviousPageLink" Text="HERE" CssClass="HeaderText" />
            to go back to our previoue page.
        </p>
        <div class="HeaderText">Support Information</div>
        <p>
            If the error contineous and you need assistance immediately,
            please contact our support group: contact@velocitycoders.com
        </p>
    </div>
</asp:Content>
