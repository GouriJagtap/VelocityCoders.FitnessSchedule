<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InstructionNavigationControl.ascx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.UserControls.WebUserControl1" %>
<div id="ContainerSubheader" class="SubheaderNavigation BorderRadiusTop">
    <asp:Label runat="server" ID="UCMessage"></asp:Label>
    <div class="SmallPadding">
        <asp:ListView runat="server" ID="InstructionNavigationList" ItemPlaceholderID="InstructorNavigationPlaceholder">
            <LayoutTemplate>
                <ul>
                    <asp:PlaceHolder runat="server" ID="InstructorNavigationPlaceholder"></asp:PlaceHolder>
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li>
                    <asp:HyperLink runat="server"
                                   Id="InstructorNavigationLink"
                                   NavigateURL='<%#Eval("Value") %>'
                                   Enable='<%#Eval("Enabled") %>'>
                                    <%#Eval("Text") %>
                    </asp:HyperLink>
                </li>
            </ItemTemplate>
        </asp:ListView>
    </div>
</div>