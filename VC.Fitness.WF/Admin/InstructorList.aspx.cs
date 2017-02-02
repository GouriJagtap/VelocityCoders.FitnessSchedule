using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.DAL;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.Models.Collections;

namespace VelocityCoders.FitnessSchedule.WebForms.Admin
{
    public partial class InstructorList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindInstructorList();
        }
        private void BindInstructorList()
        {
            InstructorCollection instructorList = new InstructorCollection();
            instructorList = InstructorDAL.GetCollection();
            rptInstructorList.DataSource = instructorList;
            rptInstructorList.DataBind();
        }
    }
}