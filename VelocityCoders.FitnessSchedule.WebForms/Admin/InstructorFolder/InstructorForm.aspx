<%@ Page    Language="C#" 
            AutoEventWireup="true" 
            CodeBehind="InstructorForm.aspx.cs" 
            MasterPageFile="~/MasterPages/Site2Column.Master"
            Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.InstructorFolder.InstructorForm"    
            EnableViewState="true"
            Theme="Theme"%>

<%@ Register TagPrefix="CustomVelocityCoders"
             TagName="InstructorNavigation"
             Src="~/UserControls/InstructionNavigationControl.ascx" %>


<asp:Content Id="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CustomVelocityCoders:InstructorNavigation runat="server" ID="instructorNavigation" />
                    <div id="InstructorContainer" class="BorderRadiusBottom">

           <p><h3>Form Values Output: <asp:Label runat="server" ID="lblPageMessage"/></h3></p>

        <table>
            <tr>
                <td><label>First Name</label></td>
                <td><asp:TextBox runat="server" ID="txtFirstName" MaxLength="50" /> </td>
            </tr>
            <tr>
                <td><label>Prefered First Name</label></td>
                <td><asp:TextBox runat="server" ID="txtPreferedFirstName" MaxLength="50" /> </td>
            </tr>
          
             <tr>
                <td><label>Last Name</label></td>
                <td><asp:TextBox runat="server" ID="txtLastName" MaxLength="50" /> </td>
            </tr>
             <tr>
                <td><label> Date Of Birth </label></td>
                <td><asp:TextBox runat="server" ID="txtBirthDate" MaxLength="10" /> </td>
            </tr>
            <td colspan="2"><hr /></td>
            <tr>
                <td><label> Date Of Hire </label></td>
                <td><asp:TextBox runat="server" ID="txtHireDate" MaxLength="10" /> </td>
            </tr>
            <tr>
                <td><label> Date Of Termination </label></td>
                <td><asp:TextBox runat="server" ID="txtTermDate" MaxLength="10" /> </td>
            </tr>
            <tr>
                <td><label> Employee Type </label></td>
                <td>
                    <asp:DropDownList runat="server" ID="drpEmployeeType">
                        <asp:ListItem Text="(Select Employee Type)" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td><label> Gender </label></td>
                <td>
                    <asp:DropDownList runat="server" ID="drpGender">
                        <asp:ListItem Text="(Select Gender)" Value="0" />
                        <asp:ListItem Text="Male" Value="Male" />
                        <asp:ListItem Text="Female" Value="Female" />
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td><label>Notes : </label></td>
                <td><asp:TextBox runat="server" ID="txtNotes" TextMode="MultiLine" /> </td>
            </tr>
        </table>
        <br />
        <asp:Button runat="server" Text="Save" OnClick="Save_Click"/>
         </div>
</asp:Content>
                    
      