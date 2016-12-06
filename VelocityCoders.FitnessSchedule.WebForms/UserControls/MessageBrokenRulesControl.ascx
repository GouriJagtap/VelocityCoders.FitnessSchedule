<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageBrokenRulesControl.ascx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.UserControls.MessageBrokenRulesControl" %>
  <asp:Panel
            runat="server"
            ID="PageMessageArea"
            CssClass="PageMessage BorderRadiusAll"
            Visible="false">
            <asp:Label runat="server" ID="PageMessage"></asp:Label> 
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
