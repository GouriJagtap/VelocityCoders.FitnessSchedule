using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jagtap.Common.Extensions;
using VelocityCoders.FitnessSchedule.DAL;
using VelocityCoders.FitnessSchedule.Models.Collections;



namespace VelocityCoders.FitnessSchedule.WebForms.Admin
{
    public partial class EmailList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindEmailList();
        }
        private void BindEmailList()
        {
            EmailCollection emailList = new EmailCollection();

            emailList = EmailDAL.GetCollection();

            //Bind to Repeater
            rptEmailList.DataSource = emailList;
            rptEmailList.DataBind();
        }

    }
}