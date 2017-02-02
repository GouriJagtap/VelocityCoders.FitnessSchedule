<%@ Page Title="Manage Gym" Theme="Theme" Language="C#" MasterPageFile="~/MasterPages/Site2Column.Master" AutoEventWireup="true" CodeBehind="GymManage.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.GymLocationArea.GymManage" %>

<%@ Register    TagPrefix="CustomVelocityCoders" 
                TagName="GymLocationNavigation"
                Src="~/UserControls/GymLocationNavigationControl.ascx"%>

<%@ Register    TagPrefix="CustomVelocityCoders"
                TagName="MessageArea"
                Src="~/UserControls/MessageBrokenRulesControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:HiddenField runat="server" ID="HiddenGymId" value="0"/>
     <CustomVelocityCoders:GymLocationNavigation runat="server" ID="gymLocationNavigation" />
    <div id="GenericContainer" class="BorderRadiusBottom">
       
            <CustomVelocityCoders:MessageArea runat="server" ID="customMessageArea" Visible="false" />
    <div class="SectionMessageArea SmallText">
        
        <label class="Required">*</label>=RequiredField</div>    
        
        <table>
            <tr>
                <td><label class="Required">Gym Name*</label></td>
                <td><asp:TextBox runat="server" ID="txtGymName" MaxLength="50"/></td>
            </tr>

            <tr>
                <td><label>Gym Abbreviation</label></td>
                <td><asp:TextBox runat="server" ID="txtGymAbbreviation" MaxLength="10"/></td>
            </tr>

              <tr>
                <td><label>Website</label></td>
                <td><asp:TextBox runat="server" ID="txtWebsite" MaxLength="100"/></td>
            </tr>

              <tr>
                <td><label>Description</label></td>
                <td><asp:TextBox runat="server" ID="txtDescription" TextMode="Multiline"/></td>
            </tr>     
             <%--<tr>
                <td><label>Create Date</label></td>
                <td><asp:TextBox runat="server" ID="txtCreateDate" MaxLength="50"/></td>
            </tr>       --%>      

        </table>
        <div class="ContainerBar">
            <asp:Button
                    runat="server"
                    Text="Add Gym"
                    ID="SaveButton"
                    OnClick="Save_Click" />
            <span class="FloatRight">
                <asp:Button
                        runat="server"
                        ID="btnCancel"
                        Text="Cancel"
                        Visible="false"
                        OnClick="Cancel_Click" />
            </span>
        </div>
    </div>
    <asp:Repeater runat="server" ID="rptGymList" OnItemDataBound="GymList_OnItemDataBound">
        <HeaderTemplate>
            <table class="ListStyle BorderRadiusAll">
                <tr>
                    <th>&nbsp</th>
                    <th>Gym</th>
                    <th>Abbreviation</th>
                    <th>Website</th>
                </tr>
            </table>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td class="CenterText">
                    <asp:LinkButton
                            runat="server"
                            ID="EditButton"
                            Text="Edit"
                            CssClass="Button ButtonRoundedLeft"
                            OnCommand="GymButton_Command"
                            CommandName="Edit" />
                     <asp:LinkButton
                            runat="server"
                            ID="DeleteButton"
                            Text="Delete"
                            CssClass="Button ButtonRoundedLeft"
                            OnCommand="GymButton_Command"
                            CommandName="Delete" />

                </td>
                
                <td class="CenterText"><%# Eval("Name") %></td>
                <td class="CenterText"><%# Eval("Abbreviation") %></td>
                <td class="CenterText"><%# Eval("Website") %></td>
            </tr>
            </br>
        </ItemTemplate>

        <AlternatingItemTemplate>
            <tr>
                <td class="ListStyleAlternate CenterText">
                    <asp:LinkButton
                            runat="server"
                            ID="EditButton"
                            Text="Edit"
                            CssClass="Button ButtonRoundedLeft"
                            OnCommand="GymButton_Command"
                            CommandName="Edit" />
                    <asp:LinkButton
                            runat="server"
                            ID="DeleteButton"
                            Text="Delete"
                            CssClass="Button ButtonRoundedLeft"
                            OnCommand="GymButton_Command"
                            CommandName="Delete" />
                </td>
                 <td class="ListStyleAlternate CenterText"><%# Eval("Name") %></td>
                <td class="ListStyleAlternate CenterText"><%# Eval("Abbreviation") %></td>
                <td class="ListStyleAlternate CenterText"><%# Eval("Website") %></td>
                    </br>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
