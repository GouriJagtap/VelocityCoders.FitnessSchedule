<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="VelocityCoders.FitnessSchedule.WebForms.Admin.Index"
    Theme="Theme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1> Content Management </h1>
        <br />
        <a href ="PersonList.aspx"> Person </a>
        <br />
        <a href ="InstructorList.aspx"> Instructor </a>
        <br />
        <a href ="EmailList.aspx"> Email </a>
        <br />
        <a href ="EntityTypeList.aspx"> EntityType </a>
        <br />
        <a href ="FitnessClassList.aspx"> Fitness Class </a>
    </div>
    </form>
</body>
</html>


<%--
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace VelocityCoders.FitnessSchedule.WebForms.Admin.LookupTablesArea
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //base.SetMasterPageNavigation(Webforms.MasterNavigation.LookupTables);
        }
    }
}--%>