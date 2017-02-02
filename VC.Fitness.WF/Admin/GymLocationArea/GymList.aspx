<%@ Page Title="GymList" Theme="Theme" Language="C#" MasterPageFile="~/MasterPages/Site2Column.Master" AutoEventWireup="true" CodeBehind="GymList.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.GymLocationArea.GymList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div>
<table>
        <asp:Repeater runat="server" ID="rptEmailList">
            <HeaderTemplate>
                <tr>
                    <td>GymId</td>
                    <td>GymName</td>
                    <td>Abbreviation</td>
                    <td>Website</td>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("GymId") %></td>
                    <td><%#Eval("GymName") %></td>
                    <td><%#Eval("Abbreviation") %></td>
                    <td><%#Eval("Website") %></td>
                    <%--<td><a href="EmailDetails.aspx?EmailId=<%#Eval("EmailId")%>">Details</a></td>--%>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    </div>
    </asp:Content>