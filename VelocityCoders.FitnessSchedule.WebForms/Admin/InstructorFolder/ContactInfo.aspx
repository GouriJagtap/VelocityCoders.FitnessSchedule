<%@ Page Title="Instructor Contact Info" 
    Theme="Theme" 
    Language="C#" 
    MasterPageFile="~/MasterPages/Site2Column.Master" 
    AutoEventWireup="true"
     CodeBehind="ContactInfo.aspx.cs" 
    Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.InstructorFolder.ContactInfo" %>

<%@ Register TagPrefix="CustomVelocityCoders" 
             TagName="InstructorNavigation" 
             Src="~/UserControls/InstructionNavigationControl.ascx" 
               %>
<%@ Register TagPrefix="CustomVelocityCoders"
             TagName="MessageArea"
             Src="~/UserControls/MessageBrokenRulesControl.ascx" 
                %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="hdnEmailId" value="0" />
    
     <CustomVelocityCoders:InstructorNavigation runat="server" ID="instructorNavigation" />
     <CustomVelocityCoders:MessageArea runat="server" ID="CustomMessageArea" />

    <div id="InstructorContainer" class="BorderRadiusBottom">
       
           <table>
           <tr>
               <td><label> Email Address:</label></td>
               <td> <asp:TextBox runat="server" ID="txtEmailAddress" MaxLength="50"/></td>
           </tr>
           <tr>
               <td><label> Email Type:</label></td>
               <td>
                   <asp:DropDownList runat="server" 
                                     ID="drpEmailType"
                                     DataTextField ="EntityTypeName"
                                     DataValueField ="EntityTypeId" />
               </td>
           </tr>
       </table>
        <div class="ContainerBar">
            <asp:Button runat="server"
                        Text ="Add Email"
                        ID="SaveButton"
                        OnClick="Save_Click" />
         </div>

        </br>
        <asp:Repeater runat="server" ID="rptEmailList" OnItemDataBound="EmailList_OnItemDataBound">
            <headerTemplate>
                <table class="ListStyle BorderRadiusAll">
                    <tr>
                        <th>&nbsp;</th>
                        <th>Email Address</th>
                        <th>Email Type</th>
                    </tr>
              
            </headerTemplate>
            <ItemTemplate>
                <tr>
                    <td class="CenterText">
                        <asp:LinkButton
                            runat="server"
                            Id="EditButton"
                            Text="Edit"
                            CssClass="Button ButtonRoundedLeft"
                            OnCommand="EmailButton_Command"
                            CommandName="Edit" />
                        <asp:LinkButton
                            runat="server"
                            ID="DeleteButton"
                            Text="Delete"
                            CssClass="Button ButtonRoundedRight"
                            OnCommand="EmailButton_Command"
                            CommandName="Delete" />

                    </td>
                    <td class="CenterText"><%# Eval("EmailValue") %></td>
                    <td class="CenterText"><%# Eval("EmailType.EntityTypeName") %></td>
                </tr>
                
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
                    <td class="ListStyleAlternate CenterText">
                        <asp:LinkButton
                            runat="server"
                            ID="EditButton"
                            Text="Edit"
                            CssClass="Button ButtonRoundedLeft"
                            OnCommand="EmailButton_Command"
                            CommandName="Edit" />
                        <asp:LinkButton
                            runat="server"
                            ID="DeleteButton"
                            Text="Delete"
                            CssClass="Button ButtonRoundedRight"
                            OnCommand="EmailButton_Command"
                            CommandName="Delete" />

                    </td>
                    <td class="ListStyleAlternate CenterText"><%#Eval("EmailValue") %></td>
                    <td class="ListStyleAlternate CenterText"><%#Eval("EmailType.EntityTypeName") %></td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </asp:Content>
