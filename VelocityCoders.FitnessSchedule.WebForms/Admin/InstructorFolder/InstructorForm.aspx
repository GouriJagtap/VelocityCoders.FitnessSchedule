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
    <asp:HiddenField runat="server" Id="hidInstructorId" value="0" />
    <asp:HiddenField runat="server" Id="hidPersonId" value="0" />
    <asp:HiddenField runat="server" ID="hndEmailId" Value="0" />

    <CustomVelocityCoders:InstructorNavigation runat="server" ID="instructorNavigation" />           
         
        <div id="InstructorContainer" class="BorderRadiusButton">
          
        <asp:Panel
            runat="server"
            ID="PageMessageArea"
            CssClass="PageMessage BorderRadiusAll"
            Visible="false">
            <asp:Label runat="server" ID="lblPageMessage"></asp:Label> 
                <asp:ListView runat="server" ID="MessageList" ItemPlaceHolderID="MessageListPlaceholder">
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder runat="server" ID="MessageListPlaceholder" />
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li><%#Eval("PropertyName") %>: <%#Eval("Message") %></li>
                    </ItemTemplate>
                </asp:ListView>
        </asp:Panel>
            <br/>
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
                    <asp:DropDownList   runat="server" 
                                        ID="drpEmployeeType" 
                                        DataTextField="EntityTypeName"
                                        DataValueField="EntityTypeId" />
                       
                    
                </td>
            </tr>
            <tr>
                <td><label> Gender </label></td>
                <td>
                    <asp:DropDownList runat="server" ID="drpGender">
                        <asp:ListItem Text="Select Gender" Value="0" />
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
        <div class="ContainerBar">
            <asp:Button runat="server" Text="Save" Id="btnSave" OnClick="Save_Click"/>
            &nbsp;&nbsp;
            <asp:Button runat="server" Text="Cancel" id="btnCancel" onClick ="Cancel_Click" />
            <span class="FloatRight">
                <asp:Button runat="server" Text="Delete" Id="btnDelete" OnClick="Delete_Click" visible="False" />
            </span>
         </div>
         </div>
</asp:Content>
                    
      