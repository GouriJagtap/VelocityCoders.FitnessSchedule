<%@ Page Title="Instructor Fitness Class"
         Theme="Theme"
         Language="C#" 
         MasterPageFile="~/MasterPages/Site2Column.Master"
         AutoEventWireup="true" 
         CodeBehind="InstructorFitnessClassAdmin.aspx.cs" 
         Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.InstructorFolder.InstructorFitnessClassAdmin" %>

<%@ Register TagPrefix="CustomVelocityCoders"
             TagName="InstructorNavigation"
             Src="~/UserControls/InstructionNavigationControl.ascx" %>

<%@ Register TagPrefix="CustomVelocityCoders"
             TagName="MessageArea"
             Src="~/UserControls/MessageBrokenRulesControl.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="/scripts/InstructorFitnessClassAdmin.js"></script>
    <asp:Literal runat="server" ID="litInstructorId"></asp:Literal>

     <CustomVelocityCoders:InstructorNavigation runat="server" ID="instructorNavigation" />
   
     <div id="InstructorContainer" class="BorderRadiusBottom">
        <div id="MessageArea" class="PageMessage BorderRadiusAll">
            <ul id="MessageAreaList"></ul>
        </div>
        <table>
            <tr>
                <td><label class="Required"> Instructor*:</label></td>
                <td><div id="InstructorName"></div></td>
            </tr>
            <tr>
                <td><label class="Required"> Fitness Class*:</label></td>
                <td>
                    <select id="drpFitnessClass">
                        <option>(Select Fitness Class)</option>
                    </select>
                    <button class="ManageButton"
                            data-option-name="FitnessClass"
                            data-option-display="Fitness Class">Add</button>
                </td>
            </tr>
            </table>
        <div class="ContainerBar"><asp:Button runat="server"
                                              Text="Associate Fitness Class"
                                              ID="SaveButton"
                                              CssClass="AssociateFitnessClassButton"
                                              OnClientClick="return ValidateClientForm()" />
            </div>
        <br />
        </div>
    <div id="FitnessClassPopupForm">
        <p class="ValidateTips">All form fields are required</p>
        <table class="BaseTable">
            <tr>
                <td><label>Name:</label></td>
                <td><input  type="text" 
                            name="FitnessClassPopupForm_NameValue"
                            id="FitnessClassPopupForm_NameValue" 
                            maxlength="50" /></td>
            </tr>
           
        </table>

    </div>
    </asp:Content>


