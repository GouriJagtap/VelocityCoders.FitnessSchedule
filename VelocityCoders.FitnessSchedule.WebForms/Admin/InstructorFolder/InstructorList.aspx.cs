using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.FitnessSchedule.Models.Collections;
using VelocityCoders.FitnessSchedule.BLL;
using Jagtap.Common;

namespace VelocityCoders.FitnessSchedule.WebForms.Admin.InstructorFolder
{
    public partial class InstructorList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindInstructorList();
        }
        #region BIND iNSTRuCTOR LIST

        private void BindInstructorList()
        {
            InstructorCollection instructorList = InstructorManager.GetCollection();
            rptInstructorList.DataSource = instructorList;
            rptInstructorList.DataBind();

        }
        #endregion

    }
}