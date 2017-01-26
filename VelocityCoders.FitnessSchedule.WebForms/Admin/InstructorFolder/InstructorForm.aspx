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

   
      <script src="/scripts/InstructorForm.js"></script>

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
            <div class="SectionMessageArea SmallText"><label class="Reqiured">*</label>=Required Field</div>
            <br/>
        <table>
            <tr>
                <td><label class="Required">First Name*</label></td>
                <td><div class="FloatLeft LineHeightMid">
                    <asp:TextBox runat="server" ID="txtFirstName" MaxLength="50" CssClass="ValidateFirstName" /> 
                    </div>

                    <div id="ValidationMessageFirstName" class="ValidationBox">
                        <div class="ValidationBoxArrowBorder"></div>
                        <div class="ValidationBoxArrow"></div>
                        <div class="ValidationContent">First Name is a required field.</div>

                    </div>
                    </td>
            
            </tr>
            <tr>
                <td><label>Prefered First Name</label></td>
                
                <td><asp:TextBox runat="server" ID="txtPreferedFirstName" MaxLength="50" />
                    
                </td>
            </tr>
          
             <tr>
                <td><label class="Required">Last Name*</label></td>
                 <td><div class="FloatLeft LineHeightMid">
                <asp:TextBox runat="server" ID="txtLastName" MaxLength="50" CssClass="ValidateLastName"/> 
                    </div>
                 <div id="ValidationMessageLastName" class="ValidationBox">
                        <div class="ValidationBoxArrowBorder"></div>
                        <div class="ValidationBoxArrow"></div>
                        <div class="ValidationContent">Last Name is a required field.</div>

                    </div>
                </td>
            </tr>
             <tr>
                <td><label> Date Of Birth </label></td>
                <td>
                    <div class="FloatLeft LineHeightMid">
                    <asp:TextBox runat="server"
                                 ID="txtBirthDate" 
                                 MaxLength="10" 
                                 CssClass="ValidateDate"
                                 data-validation-message-id="ValidationMessageDOB" />

                        </div>
                    <div id="ValidationMessageDOB" class="ValidationBox">
                        <div class="ValidationBoxArrowBorder"></div>
                        <div class="ValidationBoxArrow"></div>
                        <div class="ValidationContent">Invalid date. Format must be mm/dd/yyyy.</div>
                    </div>
               </td>
            </tr>
            <td colspan="2"><hr /></td>
            <tr>
                <td><label> Date Of Hire </label></td>
                <td>
                    <div class="FloatLeft LineHeightMid">
                        <asp:TextBox runat="server" 
                                     ID="txtHireDate" 
                                     MaxLength="10"
                                     CssClass="ValidateDate"
                                     data-validation-message-id="ValidationMessageDateOfHire" />
                         </div>
                    <div id="ValidationMessageDateOfHire" class="ValidationBox">
                        <div class="ValidationBoxArrowBorder"></div>
                        <div class="ValidationBoxArrow"></div>
                        <div class="ValidationContent">Invalid date. Format must be mm/dd/yyyy.</div>
                    </div>
               </td>
             </tr>
            <tr>
                <td><label> Date Of Termination </label></td>
                <td>
                    <div class="FloatLeft LineHeightMid">
                    <asp:TextBox runat="server" 
                                 ID="txtTermDate" 
                                 MaxLength="10"
                                 CssClass="ValidateDate"
                                 data-validation-message-id="ValidationMessageDateOfTerm"  />
                       </div>
                     <div id="ValidationMessageDateOfTerm" class="ValidationBox">
                        <div class="ValidationBoxArrowBorder"></div>
                        <div class="ValidationBoxArrow"></div>
                        <div class="ValidationContent">Invalid date. Format must be mm/dd/yyyy.</div>
                    </div>
                  </td>
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
            <asp:Button runat="server" Text="Save" Id="btnSave" OnClick="Save_Click" CssClass="SaveButton"/>
            &nbsp;&nbsp;
            <asp:Button runat="server" Text="Cancel" id="btnCancel" onClick ="Cancel_Click" />
            <span class="FloatRight">
                <asp:Button runat="server" Text="Delete" Id="btnDelete" OnClick="Delete_Click" visible="False" />
            </span>
         </div>
         </div>
</asp:Content>
                    
      